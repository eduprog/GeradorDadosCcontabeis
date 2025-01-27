using System.ComponentModel;

namespace GeradorDadosCcontabeis.Models.Enums;

/// <summary>
/// ECstAplicacao
/// </summary>
//TODO: Criado esse enumerador em duas entidades. Verificar depois a necessidade de dividir em dois enumeradores separados.
public enum ECstAplicacao
{
    [Description("Entrada")]
    Entrada = 0,
    [Description("Saída")]
    Saida = 1
}
