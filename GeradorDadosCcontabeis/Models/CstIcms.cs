using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Models.Enums;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Código de Situação Tribútária do Imposto sobre Circulação de Mercadorias e Prestação de Serviços
/// </summary>
public class CstIcms : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Chave Estrangeira da tabela Origem_CST.
    /// Sua finalidade é compor o primeiro digito CST ICMS que define a origem da mercadoria/nacionalidade.
    /// Tabela padrão possui valor de 0 a 8 (https://www.sinconecta.com/index.php/2017/06/16/icms-tabela-de-origem-da-mercadoria/)
    /// </summary>
    public EOrigemCst OrigemCst { get; set; } = EOrigemCst.Nacional;

    /// <summary>
    /// Composto por 3 digitos, e define a situação trbutária da operacao para os regimes tributarios
    /// Normal ou de Lucro Presumido, formando o tipo de calculo exigido pela legislacao sobre a circulacao
    /// da mercadoria.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (ICMS) utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define se o Codigo (ICMS) utilizado deve ou nao gerar valores base para calculo sobre aliquota
    /// do estado ou definida contabilmente para o regime da empresa.
    /// Este calculo poderá compor apuracoes fiscais sobre os documentos aos quais foram utilizados.
    /// </summary>
    public bool GeraBaseCalc { get; set; }

    /// <summary>
    /// Define a disponibilidade para uso 
    /// </summary>
    public bool Ativo { get; set; } = true;
}
