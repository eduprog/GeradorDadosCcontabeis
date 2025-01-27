using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Nomenclatura Comum do Mercosul
/// </summary>
public class Ncm : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 8 digitos.
    /// Sendo o Primeiro representando o Produto, o segundo e o terceiro representando o desdobramento
    /// ou posição deste produto de acordo a tabela de classificação item, quinto e o sexto representam
    /// subcategoria do produto, o setimo diz respeito a classificação do item e o oitavo tambem fala
    /// sobre a classificacao porem detalhada.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Composto por 2 digitos.
    /// Utilizada pela tabela TIPI para identificar alguma diferença sobre a alíquota do IPI, ou regra
    /// da NCM, em relação à tributação de um item específico.
    /// </summary>
    public string Excecao { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Classificacao do Tipo de Produto de acordo com o Codigo.
    /// </summary>
    public string Descricao {  get; set; } = string.Empty;

    /// <summary>
    /// Campo identificador de alguns NCMS, para situações especificas.
    /// O Indicador de Escala Relevante é um novo campo na NF-e, nele indica-se bens e mercadorias
    /// que podem não se submeter ao regime de Substituição Tributária.
    /// Ele foi instituído de acordo com o Convênio ICMS 52/2017.
    /// </summary>
    public bool ObrigaIndEscalaRelevante { get; set; }

    /// <summary>
    /// Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para
    /// calculo de Tributos Federais sobre o total do documento onde o produto vendido conter o NCM.
    /// Esta aliquota pode variar por NCM.
    /// </summary>
    public decimal AliquotaFederal { get; set; } = 0m;

    /// <summary>
    /// Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para
    /// calculo de Tributos Federais para Importacao, sobre o total do documento onde o produto vendido
    /// conter o NCM. Esta aliquota pode variar por NCM.
    /// </summary>
    public decimal AliquotaFederalImportados { get; set; } = 0m;

    /// <summary>
    /// ccccccc
    /// </summary>
    public decimal AliquotaEstadual { get; set; } = 0m;

    /// <summary>
    /// Pode conter até 15 digitos inteiros seguidos de 4 casas decimais e refere-se as Aliquotas para
    /// calculo de Tributos Municipais sobre o total do documento onde o produto vendido conter o NCM.
    /// Esta aliquota pode variar por NCM.
    /// </summary>
    public decimal AliquotaMunicipal { get; set; } = 0m;

    /// <summary>
    /// Define a disponibilidade para o uso.
    /// </summary>
    public bool Ativo { get; set; } = true;
}
