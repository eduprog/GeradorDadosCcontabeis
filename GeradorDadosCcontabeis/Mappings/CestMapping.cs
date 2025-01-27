using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core para a tabela cest.
/// </summary>
internal class CestMapping : IEntityTypeConfiguration<Cest>
{
    public void Configure(EntityTypeBuilder<Cest> builder)
    {
        builder.ToTable("cest", t => t.HasComment("Tabela contendo os dados de Código Especificador da Substituição Tributária"));

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(7)
            .HasComment("Composto por 7 digitos. Os dois primeiros indica o segmento-nincho, do terceiro ao quinto o segmento do item, sexto e setimo correspondem a especificacao. | Default")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(255)
            .HasComment("Descreve a identificação a qual o código cest se refere | limitar a 255 caracteres")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso. | Default True")
            .HasDefaultValue(false)
            .IsRequired();

    }
}
