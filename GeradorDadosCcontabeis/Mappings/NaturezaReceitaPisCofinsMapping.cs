using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core da tabela natureza_receita_pis_cofins
/// </summary>
internal class NaturezaReceitaPisCofinsMapping : IEntityTypeConfiguration<NaturezaReceitaPisCofins>
{
    public void Configure(EntityTypeBuilder<NaturezaReceitaPisCofins> builder)
    {
        builder.ToTable("natureza_receita_pis_cofins", e => e.HasComment("Tabela contendo os dados relativos a Natureza de Receita PIS/COFINS"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(3)
            .HasComment("Composto por 3 digitos, O Código da Natureza da Receita do PIS e da COFINS é um código exigido na escrituração fiscal do SPED-CONTRIBUIÇÕES, para detalhamento das receitas isentas, não alcançadas pela incidência da contribuição, sujeitas a alíquota zero ou de vendas com suspensão. | Limitar a 3 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descreve a finalidade do Codigo utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
