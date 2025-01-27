using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Código de situação da operação do Simples Nacional
/// </summary>
public class Csosn : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 4 digitos, e defini a situação trbutária da operacao de
    /// Regime Simples Nacional ou Micro Empreendedor Individual- MEI, formando
    /// o tipo de calculo exigido pela legislacao sobre a circulacao da mercadoria.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (ICMS) utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;
}
