using System.Data.Common;
using Dapper;
using GeradorDadosCcontabeis.dadosiniciais;
using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace GeradorDadosCcontabeis;

public class Program
{
    // ReSharper disable once InconsistentNaming
    private const string STR_CONNECTION = "Host=localhost;Port=5432;Database=registros_contabeis;Username=postgres;Password=autocom;Include Error Detail=true;Search Path=base_inicial";
    private const string STR_SCHEMANAME = "base_inicial";
    public static void Main(string[] args)
    {
        var logFileName = $"logs/app_{DateTime.Now:yyyyMMdd_HHmmss}.log"; // Formato do nome do arquivo
        // Configuração do Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information() // Define o nível mínimo de log
            .WriteTo.File(logFileName, // Caminho do arquivo de log
                rollingInterval: RollingInterval.Infinite, // Cria um novo arquivo a cada dia
                retainedFileCountLimit: 30) // Mantém os últimos 30 arquivos de log
            .CreateLogger();

        try
        {
            Console.WriteLine("Iniciando a execução do sistema..."); 
            
            var contexto = new AppDbContext(nomeEsquema: STR_SCHEMANAME, strConnection: STR_CONNECTION);

            Log.Information("Iniciando...");

            ExecutaSqlDapper<CfopsSql, Cfop>(contexto);
            ExecutaSqlDapper<ClassificacaoItemSql, ClassificacaoItem>(contexto);
            ExecutaSqlDapper<CodigosEnquadramentoIpiSql, CodigoEnqIpi>(contexto);
            ExecutaSqlDapper<CsosnsSql, Csosn>(contexto);
            ExecutaSqlDapper<CstsIcmsSql, CstIcms>(contexto);
            ExecutaSqlDapper<CstsIpiSql, CstIpi>(contexto);
            ExecutaSqlDapper<CstsPisCofinsSql, CstPisCofins>(contexto);
            ExecutaSqlDapper<GenerosProdutoServicoSql, GeneroProdutoServico>(contexto);
            ExecutaSqlDapper<NaturezasReceitaPisCofinsSql, NaturezaReceitaPisCofins>(contexto);
            ExecutaSqlDapper<NcmsSql, Ncm>(contexto);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Erro ao executar o sistema.");
            Console.WriteLine("Ocorreu um erro inesperado. Verifique o log para mais detalhes.");
        }
        finally
        {
            Log.Information("Programa finalizado...");
            Log.CloseAndFlush();
            Console.WriteLine("Execução sistema Finalizada.");

        }
    }


    private static void ExecutaSqlDapper<TENTIDADE, TModel>(DbContext context)
        where TENTIDADE : ISql
        where TModel : class, new()
    {
        TENTIDADE entidade = Activator.CreateInstance<TENTIDADE>();
        var entityType = context.Model.FindEntityType(typeof(TModel));
        if (entityType == null)
            throw new InvalidOperationException($"Tipo de entidade {typeof(TModel).Name} não encontrado no contexto.");
        var schemaName = entityType.GetSchema() ?? "public";

        DbConnection connection = context.Database.GetDbConnection();

        int erros = 0;
        Log.Information($"Executando sql na conexão: {connection.ConnectionString}");
        Console.WriteLine($"SQL sendo executado em {entityType?.ClrType.Name}.");

        //connection.Execute($"SET search_path TO {schemaName};");
        foreach (var sqlAcao in entidade.Sql)
        {
            try
            {
                Log.Information($"Executando SQL: {sqlAcao} no schema: {schemaName}");
                connection.Execute(sqlAcao);

            }
            catch (Exception ex)
            {
                erros++;
                Log.Error(ex, $"Erro ao executar SQL: {sqlAcao}");
            }
        }

        if (erros > 0)
        {
            Log.Warning($"!ÃTENÇÃO! SQL executado com {erros} ERROS em {entityType?.ClrType.Name}.");
            Console.WriteLine($"!ÃTENÇÃO! SQL executado com {erros} ERROS em {entityType?.ClrType.Name}.");
        }
        else
        {
            Log.Information($"SQL executado com sucesso em {entityType?.ClrType.Name}.");
            Console.WriteLine($"SQL executado com sucesso em {entityType?.ClrType.Name}.");
        }

    }
}
