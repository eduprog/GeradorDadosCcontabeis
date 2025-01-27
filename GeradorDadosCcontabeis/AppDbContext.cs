using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Contexts.Mappings;
using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDadosCcontabeis;

public class AppDbContext(string nomeEsquema,string strConnection) : DbContext
{


    public DbSet<Cest> Cest { get; set; }
    public DbSet<Cfop> Cfop { get; set; }

    public DbSet<ClassificacaoItem> ClassificacaoItem { get; set; }

    public DbSet<CodigoEnqIpi> CodigoEnqIpi { get; set; }

    public DbSet<Csosn> Csosn { get; set; }

    public DbSet<CstIcms> CstIcms { get; set; }

    public DbSet<CstIpi> CstIpi { get; set; }

    public DbSet<CstPisCofins> CstPisCofins { get; set; }

    public DbSet<GeneroProdutoServico> GeneroProdutoServico { get; set; }

    public DbSet<NaturezaReceitaPisCofins> NaturezaReceitaPisCofins { get; set; }

    public DbSet<Ncm> Ncm { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(nomeEsquema);
        modelBuilder.ApplyConfiguration(new CestMapping());
        modelBuilder.ApplyConfiguration(new CfopMapping());
        modelBuilder.ApplyConfiguration(new ClassificacaoItemMapping());
        modelBuilder.ApplyConfiguration(new CodEnqIpiMapping());
        modelBuilder.ApplyConfiguration(new CsosnMapping());
        modelBuilder.ApplyConfiguration(new CstIcmsMapping());
        modelBuilder.ApplyConfiguration(new CstIpiMapping());
        modelBuilder.ApplyConfiguration(new CstPisCofinsMapping());
        modelBuilder.ApplyConfiguration(new GeneroProdutoServicoMapping());
        modelBuilder.ApplyConfiguration(new NaturezaReceitaPisCofinsMapping());
        modelBuilder.ApplyConfiguration(new NcmMapping());
        modelBuilder.ToSnakeCaseNames();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(strConnection);

    }
}