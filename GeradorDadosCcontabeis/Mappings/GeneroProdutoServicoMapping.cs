using GeradorDadosCcontabeis.Models;
using GeradorDadosCcontabeis.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core da tabela genero_produto_servico
/// </summary>
internal class GeneroProdutoServicoMapping : IEntityTypeConfiguration<GeneroProdutoServico>
{
    public void Configure(EntityTypeBuilder<GeneroProdutoServico> builder)
    {
        builder.ToTable("genero_produto_servico", e => e.HasComment("Tabela contendo os dados de Genero de Produto e Serviço"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(2)
            .HasComment("Composto por 2 digitos. Codigo utilizado na definicao do tipo item de mercadoria/servico e é exigido no EFD Contribuicoes do Sped para os regimes tributarios do tipo Normal ou Lucro Presumido. | Limitar a 2 digitos e nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Decreve o Item em coerencia ao Codigo utilizado. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.TipoProdutoServico)
            .HasColumnName("tipo_produto_servico")
            .HasComment("Defini o tipo de mercadoria entre Produto/Servico. Sendo 0 para Produto e 1 para Servicos. | Default = 0 Produto e nao pode ser nulo.")
            .HasDefaultValue(ETipoProdutoServico.Produto)
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_codigo_genero_prod_serv")
            .IsUnique();
    }
}
