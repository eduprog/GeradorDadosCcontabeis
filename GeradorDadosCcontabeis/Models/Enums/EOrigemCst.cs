using System.ComponentModel;

namespace GeradorDadosCcontabeis.Models.Enums;

/// <summary>
/// Relativo ao código de Origem do CST
/// </summary>
public enum EOrigemCst
{
    [Description("Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8.")]
    Nacional = 0,

    [Description("Estrangeira – Importação direta, exceto a indicada no código 6")]
    EstrangeiraImportacaoDireta = 1,

    [Description("Estrangeira – Adquirida no mercado interno, exceto a indicada no código 7.")]
    EstrangeiraAdquiridoMercadoInterno = 2,

    [Description("Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40%\r\n " +
        "(quarenta por cento) e inferior ou igual a 70% (setenta por cento).")]
    NacionalConteudoImportacaoEntre40e70 = 3,

    [Description("Nacional, cuja produção tenha sido feita em conformidade com os processos\r\n" +
        " produtivos básicos(PPB) de que tratam o Decreto-Lei nº 288/1967, e as\r\n" +
        " Leis nºs 8.248/1991, 8.387/1991, 10.176/2001 e 11.484/2007.")]
    NacionalPPB = 4,

    [Description("Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40% (quarenta por cento).")]
    NacionalConteudoImportacaoAte40 = 5,

    [Description("Estrangeira – Importação direta, sem similar nacional, constante em lista de Resolução CAMEX e gás natural.")]
    EstrangeiraImportacaoDiretaSemSimilarNacional = 6,

    [Description("Estrangeira – Adquirida no mercado interno, sem similar nacional, constante em lista" +
        " de Resolução CAMEX e gás natural.")]
    EstrangeiraAdquiridoMercadoInternoSemSimilarNacional = 7,

    [Description("Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).")]
    NacionalConteudoImportacaoSuperior70 = 8
}
