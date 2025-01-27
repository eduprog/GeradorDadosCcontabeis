using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Codigo Enquadramento IPI
/// </summary>
public class CodigoEnqIpi : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 3 digitos, que estão associados à finalidade e ao destino
    /// da operação descrita na Nota Fiscal.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o Código (IPI) utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;
}
