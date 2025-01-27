using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core da tabela csosn
/// </summary>
internal class CsosnMapping : IEntityTypeConfiguration<Csosn>
{
    public void Configure(EntityTypeBuilder<Csosn> builder)
    {
        builder.ToTable("csosn", e => e.HasComment("Tabela contendo os dados de Código de Situação da Operação no Simples Nacional"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(4)
            .HasComment("Composto por 4 digitos, e defini a situação trbutária da operacao de Regime Simples Nacional ou Micro Empreendedor Individual- MEI, formando o tipo de calculo exigido pela legislacao sobre a circulacao da mercadoria. | Limitar a 4 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(500)
            .HasComment("Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (ICMS) utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso | Defaut True")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_csosn.codigo")
            .IsUnique();

    }
}
