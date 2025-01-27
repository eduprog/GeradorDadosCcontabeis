using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Models.Enums;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// Cfop
/// </summary>
public class Cfop : EssencialEntity, IAggregateRoot
{
    /// <summary>
    /// Composto por 4 digitos. O primeiro digito determina a movimentacao do 
    /// item pelo tipo entrada ou saida. Sendo 1,2,3 para entrada e 5,6,7 para saida.
    /// O segundo digito mostra qual o grupo ou operacao referida no documento.
    /// O terceiro e o quarto o tipo de prestacao ou de operacao.
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descricao padrão tabela CFOP de acordo com suas definicoes.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Descricao para apresentacao ao usario de forma simplificada na selecao de uso do Codigo-CFOP.
    /// </summary>
    public string DescricaoResumida { get; set; } = string.Empty;

    /// <summary>
    /// Defini o resultado da movimentacao entre Entrada ou Saida.
    /// Sendo 0 para Entrada e 1 para saida. 
    /// </summary>
    public ETipoCfop TipoCfop { get; set; } = ETipoCfop.Entrada;

    /// <summary>
    /// Define a disponibilidade para uso
    /// </summary>
    public bool Ativo { get; set; } = true;
}
