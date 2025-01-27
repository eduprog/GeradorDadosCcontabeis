using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;
internal class CstPisCofinsMapping : IEntityTypeConfiguration<CstPisCofins>
{
    public void Configure(EntityTypeBuilder<CstPisCofins> builder)
    {
        builder.ToTable("cst_pis_cofins", e => e.HasComment("Tabela contendo os dados de Código de Situação Tributária de PIS/COFINS"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .HasComment("Composto por 2 digitos, e defini a situação trbutária da operacao, formando o tipo de calculo exigido pela legislacao sobre a circulacao da mercadoria. | Limitar a 2 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (CST - Pis-Cofins) utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Aplicacao)
            .HasColumnName("aplicacao")
            .HasComment("Define em qual situação deve ser considerado a aplicação do codigo tributário e seus devidos calculos. Tendo como padrão Aplicação = 0 para Entrada e Aplicação = 1 para Saidas. | Campo Selecao Default 0 = Entrada. Não pode ser nulo.")
            //.HasDefaultValue()
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_cst_pis_cofins.codigo")
            .IsUnique();

    }
}
