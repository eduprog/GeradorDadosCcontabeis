using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela cod_enq_ipi
/// </summary>
internal class CodEnqIpiMapping : IEntityTypeConfiguration<CodigoEnqIpi>
{
    public void Configure(EntityTypeBuilder<CodigoEnqIpi> builder)
    {
        builder.ToTable("cod_enq_ipi", e => e.HasComment("Tabela contendo os dados de Enquadramento de IPI (Imposto sobre Produtos Industrializados)"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(3)
            .HasComment("Composto por 3 digitos, que estão associados à finalidade e ao destino da operação descrita na Nota Fiscal. | Limitar a 3 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (IPI) utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_cod_enq_ipi.codigo")
            .IsUnique();
    }
}
