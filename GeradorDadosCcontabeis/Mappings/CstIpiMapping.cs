using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis.Contexts.Mappings;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela cst_ipi
/// </summary>
internal class CstIpiMapping : IEntityTypeConfiguration<CstIpi>
{
    public void Configure(EntityTypeBuilder<CstIpi> builder)
    {
        builder.ToTable("cst_ipi", e => e.HasComment("Tabela contendo dados de Código de Situação Tributária de Imposto sobre Produtos Industrializados"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .HasComment("Composto por 2 digitos, e defini a situação trbutária da operacao. | Limitar a 2 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (IPI) utilizado. | Limitar a 100 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Aplicacao)
            .HasColumnName("aplicacao")
            .HasComment("Defini se o calculo dos tributos sobre o codigo IPI devem serem aplicados em tipo de Movimentacao de um documento Entrada ou Saida. Sendo 0 para entrada e 1 para tipo Saida. | Default = 0 Entrada, nao pode ser nulo.")
            //.HasDefaultValue(ECstAplicacao.Entrada)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("cst_ipi_ix_cst_ipi")
            .IsUnique();
    }
}
