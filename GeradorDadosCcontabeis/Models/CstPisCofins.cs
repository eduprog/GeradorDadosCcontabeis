using Essencial.Framework.Core;
using GeradorDadosCcontabeis.Models.Enums;

namespace GeradorDadosCcontabeis.Models;

/// <summary>
/// CstPisCofins
/// </summary>
public class CstPisCofins : EssencialEntity, IAggregateRoot
{
    /// <summary>
    ///  Composto por 2 digitos, e define a situação trbutária da operacao, formando
    ///  o tipo de calculo exigido pela legislacao sobre a circulacao da mercadoria.
    /// </summary> 
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Descreve o Tipo de Situacao Tributária esta sendo aplicada sobre o 
    /// Código (CST - Pis-Cofins) utilizado. 
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Define em qual situação deve ser considerado a aplicação do codigo tributário
    /// e seus devidos calculos.
    /// Tendo como padrão Aplicação = 0 para Entrada e Aplicação = 1 para Saidas.
    /// </summary>
    public ECstAplicacao Aplicacao { get; set; } = ECstAplicacao.Entrada;

    /// <summary>
    /// Define a disponibilidade para uso.
    /// </summary>
    public bool Ativo { get; set; } = true;
}
