using GeradorDadosCcontabeis.Models;
using GeradorDadosCcontabeis.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela cfop
/// </summary>
internal class CfopMapping : IEntityTypeConfiguration<Cfop>
{
    public void Configure(EntityTypeBuilder<Cfop> builder)
    {
        builder.ToTable("cfop", x => x.HasComment("Tabela contendo os dados de Código Fiscal da Operação Padrão."));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(4)
            .HasComment("Composto por 4 digitos. O primeiro digito determina a movimentacao do item pelo tipo entrada ou saida. Sendo 1,2,3 para entrada e 5,6,7 para saida. O segundo digito mostra qual o grupo ou operacao referida no documento. O terceiro e o quarto o tipo de prestacao ou de operacao. | Nao pode ser Nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder
            .Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descricao padrão tabela CFOP de acordo com suas definicoes. Limitar a 1000 caracteres | Nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();
       
        builder
            .Property(e => e.DescricaoResumida)
            .HasColumnName("descricao_resumida")
            .HasMaxLength(500)
            .HasComment("Descricao para apresentacao ao usario de forma simplificada na selecao de uso do Codigo-CFOP. Limitar a 500 caracteres. | Nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.TipoCfop)
            .HasColumnName("tipo_cfop")
            .HasComment(
                "Defini o resultado da movimentacao entre Entrada ou Saida. Sendo 0 para Entrada e 1 para saida. | Default 0 Entrada e nao pode ser nulo.")
            .HasDefaultValue(ETipoCfop.Entrada)
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.|Default true")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("idx_cfop.codigo")
            .IsUnique();

    }
}
