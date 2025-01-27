using GeradorDadosCcontabeis.Models;
using GeradorDadosCcontabeis.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis.Contexts.Mappings;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela cst_icms.
/// </summary>
internal class CstIcmsMapping : IEntityTypeConfiguration<CstIcms>
{
    public void Configure(EntityTypeBuilder<CstIcms> builder)
    {
        builder.ToTable("cst_icms", e => e.HasComment("Tabela contendo os dados de Código de Situação Tributária de Imposto sobre Circulação de Mercadorias e Prestação de Serviços"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrigemCst)
            .HasColumnName("origem_cst")
            .HasComment("Chave Estrangeira da tabela Origem_CST. Sua finalidade é compor o primeiro digito CST ICMS que define a origem da mercadoria/nacionalidade. Tabela padrão possui valor de 0 a 8 (https://www.sinconecta.com/index.php/2017/06/16/icms-tabela-de-origem-da-mercadoria/) | Int e Default 0. Não pode ser nulo.")
            .HasDefaultValue(EOrigemCst.Nacional)
            .IsRequired();

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasColumnType("TEXT")
            .HasMaxLength(3)
            .HasComment("Composto por 3 digitos, e defini a situação trbutária da operacao para os regimes tributarios Normal ou de Lucro Presumido, formando o tipo de calculo exigido pela legislacao sobre a circulacao da mercadoria. | Limitar a 3 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasColumnType("TEXT")
            .HasMaxLength(500)
            .HasComment("Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (ICMS) utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.GeraBaseCalc)
            .HasColumnName("gera_base_calc")
            .HasComment("Defini se o Codigo (ICMS) utilizado deve ou nao gerar valores base para calculo sobre aliquota do estado ou definida contabilmente para o regime da empresa. Este calculo poderá compor apuracoes fiscais sobre os documentos aos quais foram utilizados. | Default False.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para usuo.")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
