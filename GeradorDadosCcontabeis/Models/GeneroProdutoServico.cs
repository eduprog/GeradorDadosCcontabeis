using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Models.Enums;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Genero Produto Servico
/// </summary>
public class GeneroProdutoServico : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 2 digitos.
    /// Codigo utilizado na definicao do tipo item de mercadoria/servico e é exigido no EFD Contribuicoes
    /// do Sped para os regimes tributarios do tipo Normal ou Lucro Presumido.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Item em coerencia ao Codigo utilizado.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define o tipo de mercadoria entre Produto/Servico.
    /// Sendo 0 para Produto e 1 para Servicos.
    /// </summary>
    public ETipoProdutoServico TipoProdutoServico { get; set; } = ETipoProdutoServico.Produto;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;
}
