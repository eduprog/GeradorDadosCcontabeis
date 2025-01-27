using GeradorDadosCcontabeis.dadosiniciais;
using System.Text.RegularExpressions;
using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GeradorDadosCcontabeis;

public class Program
{
    public static string StrConnection =
        "Host=localhost;Port=5432;Database=registros_contabeis;Username=postgres;Password=autocom;Include Error Detail=true";

    public static void Main(string[] args)
    {
        var contexto = new AppDbContext();

       // ExecutaSql<CstsIpiSql, CstIpi>(contexto);
       //ExecutaSql<CstsIcmsSql,CstIcms>(contexto);
       //ExecutaSql<CsosnsSql,Csosn>(contexto);
       ExecutaSql<GenerosProdutoServicoSql,GeneroProdutoServico>(contexto);

    }


    private void GerarCstIcms()
    {

    }


    private static void ExecutaSql<TENTIDADE, TMODEL>(DbContext context)
        where TENTIDADE : ISql
        where TMODEL : class, new()
    {
        var entidade = Activator.CreateInstance<TENTIDADE>();
        foreach (var sqlAcao in entidade.Sql)
        {
            var entidadeRecuperada = ParseSqlToEntity<TMODEL>(sqlAcao, context);
            context.Set<TMODEL>().Add(entidadeRecuperada);
            context.SaveChanges();
        }

    }

    #region Iniciais

    private static TEntity ParseSqlToEntity_Inicial<TEntity>(string sql, Guid createdBy) where TEntity : ISql
    {
        // Supondo que a string seja sempre no formato de INSERT INTO
        var match = Regex.Match(sql, @"VALUES\s*\((.*?)\)", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new FormatException("Formato de SQL inválido.");

        var values = match.Groups[1].Value.Split(',')
            .Select(v => v.Trim().Trim('\''))
            .ToArray();

        if (values.Length < 4)
            throw new InvalidOperationException("Dados insuficientes na SQL.");

        return default;
    }


    private static TEntity ParseSqlToEntity_inicial2<TEntity>(string sql, Guid createdBy) where TEntity : ISql
    {
        // Regex para capturar os valores dentro da cláusula VALUES
        var match = Regex.Match(sql, @"VALUES\s*\((.*?)\)", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new FormatException("Formato de SQL inválido.");

        // Extrai os valores e remove espaços/desnecessários
        var values = match.Groups[1].Value.Split(',')
            .Select(v => v.Trim().Trim('\''))
            .ToArray();

        // Cria uma nova instância da entidade
        var entity = Activator.CreateInstance<TEntity>();

        // Obtém as propriedades da entidade
        var properties = typeof(TEntity).GetProperties();

        // Itera sobre as propriedades e atribui os valores correspondentes
        for (int i = 0; i < values.Length && i < properties.Length; i++)
        {
            var property = properties[i];

            // Ignora propriedades que não podem ser gravadas
            if (!property.CanWrite)
                continue;

            try
            {
                // Converte o valor para o tipo da propriedade
                var convertedValue = Convert.ChangeType(values[i], property.PropertyType);

                // Define o valor na propriedade da entidade
                property.SetValue(entity, convertedValue);
            }
            catch
            {
                throw new InvalidCastException(
                    $"Não foi possível converter o valor '{values[i]}' para o tipo {property.PropertyType.Name}.");
            }
        }

        return entity;
    }


    private static TEntity ParseSqlToEntity_inicial3<TEntity>(string sql, Guid createdBy) where TEntity : class, new()
    {
        // Regex para capturar as colunas e os valores
        var match = Regex.Match(sql, @"INSERT INTO .*?\((.*?)\)\s*VALUES\s*\((.*?)\)", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new FormatException("Formato de SQL inválido.");

        // Extrai os nomes das propriedades (colunas)
        var propertyNames = match.Groups[1].Value.Split(',')
            .Select(p => p.Trim().Trim('\''))
            .ToArray();

        // Extrai os valores
        var values = match.Groups[2].Value.Split(',')
            .Select(v => v.Trim().Trim('\''))
            .ToArray();

        if (propertyNames.Length != values.Length)
            throw new InvalidOperationException("Número de colunas e valores não correspondem.");

        // Cria um dicionário de <Propriedade, Valor>
        var propertyValueMap = propertyNames
            .Zip(values, (property, value) => new { Property = property, Value = value })
            .ToDictionary(x => x.Property, x => x.Value);

        // Cria a instância da entidade
        var entity = new TEntity();

        // Configura as propriedades usando o dicionário
        foreach (var propertyInfo in typeof(TEntity).GetProperties())
        {
            if (propertyValueMap.TryGetValue(propertyInfo.Name.ToUpper(), out var value) && propertyInfo.CanWrite)
            {
                try
                {
                    object? convertedValue;

                    if (propertyInfo.PropertyType.IsEnum)
                    {
                        // Converte para enum
                        convertedValue = Enum.Parse(propertyInfo.PropertyType, value, ignoreCase: true);
                    }
                    else if (propertyInfo.PropertyType == typeof(bool))
                    {
                        // Converte para boolean
                        convertedValue = bool.TryParse(value, out var boolResult)
                            ? boolResult
                            : int.TryParse(value, out var intResult) && intResult != 0;
                    }
                    else if (propertyInfo.PropertyType == typeof(decimal))
                    {
                        // Converte para decimal
                        convertedValue = Convert.ToDecimal(value);
                    }
                    else
                    {
                        // Converte para o tipo apropriado
                        convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                    }
                    propertyInfo.SetValue(entity, convertedValue);
                }
                catch
                {
                    throw new InvalidCastException(
                        $"Não foi possível converter o valor '{value}' para o tipo {propertyInfo.PropertyType.Name}.");
                }
            }
        }

        // Configura a propriedade CreatedBy, se existir
        var createdByProperty = typeof(TEntity).GetProperty("CreatedBy");
        createdByProperty?.SetValue(entity, createdBy);

        return entity;
    }
    #endregion

    public static TEntity ParseSqlToEntity<TEntity>(string sql, DbContext dbContext, Guid? createdBy = null) where TEntity : class, new()
    {
        createdBy ??= Guid.Empty;

        // Verificar se o SQL segue o padrão esperado
        var match = Regex.Match(sql, @"INSERT\s+INTO\s+.*?\((.*?)\)\s+VALUES\s*\((.*?)\)", RegexOptions.IgnoreCase);
        if (!match.Success)
            throw new FormatException("Formato de SQL inválido.");

        // Extrair os nomes das colunas e os valores correspondentes
        var columnNames = match.Groups[1].Value.Split(',').Select(c => c.Trim().Trim('"', '\'')).ToArray();
        var values = match.Groups[2].Value.Split(',').Select(v => v.Trim().Trim('"', '\'')).ToArray();

        if (columnNames.Length != values.Length)
            throw new InvalidOperationException("O número de colunas não corresponde ao número de valores.");

        // Obter o modelo do EF para TEntity
        var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
        if (entityType == null)
            throw new InvalidOperationException($"Tipo de entidade {typeof(TEntity).Name} não encontrado no contexto.");

        // Obter mapeamento de propriedades para colunas
        var propertyColumnMap = entityType.GetProperties()
            .ToDictionary(
                p => p.GetColumnName(StoreObjectIdentifier.Table(entityType.GetTableName(), entityType.GetSchema()))!,
                p => p.Name,
                StringComparer.OrdinalIgnoreCase // Ignorar case nos nomes das colunas
            );

        // Criar a entidade
        var entity = new TEntity();

        // Configurar as propriedades
        for (int i = 0; i < columnNames.Length; i++)
        {
            

            var columnName = columnNames[i];
            var value = values[i];

            if (propertyColumnMap.TryGetValue(columnName, out var propertyName))
            {
                var propertyInfo = typeof(TEntity).GetProperty(propertyName);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    try
                    {
                        // Conversão personalizada de valores
                        object? convertedValue = ConvertValue(propertyInfo.PropertyType, value);
                        propertyInfo.SetValue(entity, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidCastException(
                            $"Erro ao converter o valor '{value}' para o tipo {propertyInfo.PropertyType.Name} da propriedade '{propertyName}'. Detalhes: {ex.Message}");
                    }
                }
            }
        }
        // Configura a propriedade CreatedBy, se existir
        var createdByProperty = typeof(TEntity).GetProperty("CreatedBy");
        createdByProperty?.SetValue(entity, createdBy);

        return entity;
    }

    // Método auxiliar para conversões personalizadas
    private static object? ConvertValue(Type targetType, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        if (targetType == typeof(string))
            return value;

        if (targetType.IsEnum)
            return Enum.Parse(targetType, value, true);

        if (targetType == typeof(bool))
        {
            if (bool.TryParse(value, out var boolValue))
                return boolValue;

            // Suporte para valores numéricos ou "0"/"1"
            return value == "1";
        }

        if (targetType == typeof(int))
            return int.Parse(value);

        if (targetType == typeof(decimal))
            return decimal.Parse(value, CultureInfo.InvariantCulture);

        if (targetType == typeof(DateTime))
            return DateTime.Parse(value, CultureInfo.InvariantCulture);

        // Outros tipos numéricos
        if (targetType == typeof(double))
            return double.Parse(value, CultureInfo.InvariantCulture);

        if (targetType == typeof(float))
            return float.Parse(value, CultureInfo.InvariantCulture);

        // Nullable<T> tratamento
        if (Nullable.GetUnderlyingType(targetType) != null)
        {
            var underlyingType = Nullable.GetUnderlyingType(targetType);
            return ConvertValue(underlyingType!, value);
        }

        throw new InvalidCastException($"Tipo '{targetType.Name}' não suportado para conversão.");
    }



}
