using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Models.Enums;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Código de Situação Tributária do Imposto sobre Produtos Industrializados
/// </summary>
public class CstIpi : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 2 digitos, e defini a situação trbutária da operacao.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (IPI) utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define se o calculo dos tributos sobre o codigo IPI devem serem aplicados
    /// em tipo de Movimentacao de um documento Entrada ou Saida.
    /// Sendo 0 para entrada e 1 para tipo Saida.
    /// </summary>
    public ECstAplicacao Aplicacao { get; set; } = ECstAplicacao.Entrada;

    /// <summary>
    /// Define a disponibilidade para uso 
    /// </summary>
    public bool Ativo { get; set; } = true;
}
