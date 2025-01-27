using System.ComponentModel;

namespace GeradorDadosCcontabeis.Models.Enums;

/// <summary>
/// Enum do tipo de CFOP
/// </summary>
public enum ETipoCfop
{
    [Description("Entrada")]
    Entrada = 0,

    [Description("Saída")]
    Saida = 1
}
