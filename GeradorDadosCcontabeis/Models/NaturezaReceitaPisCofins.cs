using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Natureza Receita Pis Cofins
/// </summary>
public class NaturezaReceitaPisCofins : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 3 digitos.
    /// O Código da Natureza da Receita do PIS e da COFINS é um código exigido na escrituração fiscal
    /// do SPED-CONTRIBUIÇÕES, para detalhamento das receitas isentas, não alcançadas pela incidência
    /// da contribuição, sujeitas a alíquota zero ou de vendas com suspensão.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve a finalidade do Codigo utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;

}
