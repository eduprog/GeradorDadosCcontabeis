using System.Text.RegularExpressions;
using GeradorDadosCcontabeis.dadosiniciais;

namespace GeradorDadosCcontabeis;
public class AvaliadorSql
{
    public List<Dictionary<string, string>> GetValuesFromSql(ISql sql)
    {
        var result = new List<Dictionary<string, string>>();
        var regex = new Regex(@"INSERT INTO \w+ \(([^)]+)\) VALUES \(([^)]+)\);", RegexOptions.IgnoreCase);

        foreach (var sqlAcao in sql.Sql)
        {
            var match = regex.Match(sqlAcao);
            if (match.Success)
            {
                var columns = match.Groups[1].Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var values = ParseValues(match.Groups[2].Value);

                var dictionary = new Dictionary<string, string>();
                for (int i = 0; i < columns.Length; i++)
                {
                    dictionary[columns[i].Trim()] = values[i].Trim();
                }

                result.Add(dictionary);
            }
        }

        return result;
    }



    public static string[] ExtractValuesGemini(string sql)
    {
        // Expressão regular para extrair os valores dentro dos parênteses
        Match match = Regex.Match(sql, @"VALUES\s*\((.*?)\)");

        if (match.Success)
        {
            string valuesString = match.Groups[1].Value;

            // Expressão regular para extrair os valores, considerando as aspas
            MatchCollection matches = Regex.Matches(valuesString, @"(?<=\(|,)\s*([^,]+?)(?=\s*(,|\)))");

            string[] values = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                values[i] = matches[i].Value.Trim('\'').Trim();
            }

            return values;
        }

        return null;
    }


    static string[] ExtractValuesNovo(string sql)
    {
        // Regex para capturar os valores dentro da cláusula VALUES
        var regex = new Regex(@"VALUES\s*\((.*?)\);", RegexOptions.IgnoreCase);
        var match = regex.Match(sql);

        if (match.Success)
        {
            // Captura o conteúdo dentro dos parênteses
            var valuesString = match.Groups[1].Value;

            // Regex para dividir os valores, considerando as aspas
            var valueRegex = new Regex(@"(?<=\(|,)\s*([^,]+?)(?=\s*(,|\)))");
            var matches = valueRegex.Matches(valuesString);

            string[] values = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                values[i] = matches[i].Value.Trim();
            }

            return values;
        }

        return null;
    }

    static string[] ExtractValues(string sql)
    {
        // Regex para capturar os valores dentro da cláusula VALUES
        var regex = new Regex(@"VALUES\s*\((.*?)\);", RegexOptions.IgnoreCase);
        var match = regex.Match(sql);

        if (match.Success)
        {
            // Captura o conteúdo dentro dos parênteses
            var valuesString = match.Groups[1].Value;

            // Divide os valores, considerando as aspas e a vírgula
            var values = Regex.Split(valuesString, @"\s*,\s*(?=(?:[^'""\\]*(?:['""\\][^'""\\]*)?)*[^'""\\]*$)");

            // Remove aspas e espaços em branco
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim().Trim('\'', '\"');
            }

            return values;
        }

        return null;
    }


    private List<string> ParseValues(string valuesString)
    {
        var values = new List<string>();
        var regex = new Regex(@"'([^']*)'|([^,]+)", RegexOptions.IgnoreCase);
        var matches = regex.Matches(valuesString);

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success)
            {
                values.Add(match.Groups[1].Value);
            }
            else
            {
                values.Add(match.Groups[2].Value);
            }
        }

        return values;
    }

    // Example usage
    public static void Avaliar()
    {
        //var generosProdutoServicoSql = new GenerosProdutoServicoSql();
        //var values = new AvaliadorSql().GetValuesFromSql(generosProdutoServicoSql);

        //foreach (var value in values)
        //{
        //    foreach (var kvp in value)
        //    {
        //        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        //    }
        //    Console.WriteLine();
        //}


        foreach (string sqlAcao in new GenerosProdutoServicoSql().Sql)
        {
            PrintValues(ExtractValuesGemini(sqlAcao));
        }

    }


    static void PrintValues(string[] values)
    {
        if (values != null)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"Valor {i + 1} = {values[i]}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum valor encontrado.");
        }
    }

}
