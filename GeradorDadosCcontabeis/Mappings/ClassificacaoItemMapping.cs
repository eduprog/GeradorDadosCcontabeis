using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela classificacao_item
/// </summary>
internal class ClassificacaoItemMapping : IEntityTypeConfiguration<ClassificacaoItem>
{
    public void Configure(EntityTypeBuilder<ClassificacaoItem> builder)
    {
        builder.ToTable("classificacao_item", e => e.HasComment("Tabela contendo os dados de Classificação de Item"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .HasComment("Composto por 2 digitos, definem o tipo de produto em circulacao. Utilizado para preenchimento do bloco K do Sped como destinacao inicial do item. | Limitar a 2 caracter (digitos) e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(100)
            .HasComment("Descreve a finalidade do Codigo utilizado. | Limitar a 100 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
