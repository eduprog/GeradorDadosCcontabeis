using GeradorDadosCcontabeis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorDadosCcontabeis;

/// <summary>
/// Mapeamento do Entity Framework Core da tabela ncm
/// </summary>
internal class NcmMapping : IEntityTypeConfiguration<Ncm>
{
    public void Configure(EntityTypeBuilder<Ncm> builder)
    {
        builder.ToTable("ncm", e => e.HasComment("Tabela contendo dados de Nomenclatura Comum do Mercosul"));

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Identificação única");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(8)
            .HasComment("Composto por 8 digitos. Sendo o Primeiro representando o Produto, o segundo e o terceiro representando o desdobramento ou posição deste produto de acordo a tabela de classificação item, quinto e o sexto representam subcategoria do produto, o setimo diz respeito a classificação do item e o oitavo tambem fala sobre a classificacao porem detalhada. | limitar a 8 digitos e não pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.Excecao)
            .HasColumnName("excecao")
            .HasMaxLength(2)
            .HasComment("Composto por 2 digitos. Utilizada pela tabela TIPI para identificar alguma diferença sobre a alíquota do IPI, ou regra da NCM, em relação à tributação de um item específico. | Default nulo - vazio.");

        builder.Property(e => e.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(1000)
            .HasComment("Descre o Tipo de Classificacao do Tipo de Produto de acordo com o Codigo. | Limitar a 500 caracteres nao pode ser nulo.")
            .HasDefaultValue("")
            .IsRequired();

        builder.Property(e => e.ObrigaIndEscalaRelevante)
            .HasColumnName("obriga_ind_escala_relevante")
            .HasComment("Campo identificador de alguns NCMS, para situações especificas. O Indicador de Escala Relevante é um novo campo na NF-e, nele indica-se bens e mercadorias que podem não se submeter ao regime de Substituição Tributária. Ele foi instituído de acordo com o Convênio ICMS 52/2017. | Default false.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(e => e.AliquotaFederal)
            .HasColumnName("aliquota_federal")
            .HasComment("Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para calculo de Tributos Federais sobre o total do documento onde o produto vendido conter o NCM. Esta aliquota pode variar por NCM. | Default = 0 nao pode ser nulo.")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.AliquotaFederalImportados)
            .HasColumnName("aliquota_federal_importados")
            .HasComment("Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para calculo de Tributos Federais para Importacao, sobre o total do documento onde o produto vendido conter o NCM. Esta aliquota pode variar por NCM. | Default = 0 nao pode ser nulo.")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.AliquotaEstadual)
            .HasColumnName("aliquota_estadual")
            .HasComment("Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para calculo de Tributos Estaduais sobre o total do documento onde o produto vendido conter o NCM. Esta aliquota pode variar por NCM. | Default = 0 nao pode ser nulo.")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.AliquotaMunicipal)
            .HasColumnName("aliquota_municipal")
            .HasComment("Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para calculo de Tributos Municipais sobre o total do documento onde o produto vendido conter o NCM. Esta aliquota pode variar por NCM. | Default = 0 nao pode ser nulo.")
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(e => e.Ativo)
            .HasColumnName("ativo")
            .HasComment("Define a disponibilidade para uso.")
            .HasDefaultValue(false)
            .IsRequired();

        builder.HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_ncm_codigo")
            .IsUnique();
    }
}
