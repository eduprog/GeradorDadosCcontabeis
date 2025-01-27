using Essencial.Framework.Core;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Classificação Item
/// </summary>
public class ClassificacaoItem : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 2 digitos, definem o tipo de produto em circulacao.
    /// Utilizado para preenchimento do bloco K do Sped como destinacao inicial do item.
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
