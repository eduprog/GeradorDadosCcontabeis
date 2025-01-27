using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Cest
/// </summary>
public class Cest : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 7 digitos. 
    /// Os dois primeiros indica o segmento-nincho, do terceiro ao quinto o segmento
    /// do item, sexto e setimo correspondem a especificacao. 
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve a identificacao a qual o codigo cest se refere.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;

}

