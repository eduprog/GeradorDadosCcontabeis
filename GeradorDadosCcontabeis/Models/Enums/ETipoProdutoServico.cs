using System.ComponentModel;

namespace GeradorDadosCcontabeis.Models.Enums;

/// <summary>
/// Define o tipo de mercadoria entre Produto e Serviço.
/// </summary>
public enum ETipoProdutoServico
{
    [Description("Produto")]
    Produto = 0,

    [Description("Serviço")]
    Servico = 1
}
