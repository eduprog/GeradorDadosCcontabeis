namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class CstsPisCofinsSql : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('01', 'OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('02', 'OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('03', 'OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA POR UNIDADE DE MEDIDA DE PRODUTO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('04', 'OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('05', 'OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('06', 'OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('07', 'OPERAÇÃO ISENTA DA CONTRIBUIÇÃO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('08', 'OPERAÇÃO SEM INCIDÊNCIA DA CONTRIBUIÇÃO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('09', 'OPERAÇÃO COM SUSPENSÃO DA CONTRIBUIÇÃO', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('49', 'OUTRAS OPERAÇÕES DE SAÍDA', 1, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('50', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA EXCLUSIVAMENTE A RECEITA TRIBUTADA NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('51', 'OPERAÇÃO COM DIREITO A CRÉDITO – VINCULADA EXCLUSIVAMENTE A RECEITA NÃO TRIBUTADA NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('52', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA EXCLUSIVAMENTE A RECEITA DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('53', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA A RECEITAS TRIBUTADAS E NÃO-TRIBUTADAS NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('54', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA A RECEITAS TRIBUTADAS NO MERCADO INTERNO E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('55', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA A RECEITAS NÃO-TRIBUTADAS NO MERCADO INTERNO E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('56', 'OPERAÇÃO COM DIREITO A CRÉDITO - VINCULADA A RECEITAS TRIBUTADAS E NÃO-TRIBUTADAS NO MERCADO INTERNO, E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('60', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA EXCLUSIVAMENTE A RECEITA TRIBUTADA NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('61', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA EXCLUSIVAMENTE A RECEITA NÃO-TRIBUTADA NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('62', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA EXCLUSIVAMENTE A RECEITA DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('63', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA A RECEITAS TRIBUTADAS E NÃO-TRIBUTADAS NO MERCADO INTERNO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('64', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA A RECEITAS TRIBUTADAS NO MERCADO INTERNO E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('65', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA A RECEITAS NÃO-TRIBUTADAS NO MERCADO INTERNO E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('66', 'CRÉDITO PRESUMIDO - OPERAÇÃO DE AQUISIÇÃO VINCULADA A RECEITAS TRIBUTADAS E NÃO-TRIBUTADAS NO MERCADO INTERNO, E DE EXPORTAÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('67', 'CRÉDITO PRESUMIDO - OUTRAS OPERAÇÕES', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('70', 'OPERAÇÃO DE AQUISIÇÃO SEM DIREITO A CRÉDITO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('71', 'OPERAÇÃO DE AQUISIÇÃO COM ISENÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('72', 'OPERAÇÃO DE AQUISIÇÃO COM SUSPENSÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('73', 'OPERAÇÃO DE AQUISIÇÃO A ALÍQUOTA ZERO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('74', 'OPERAÇÃO DE AQUISIÇÃO SEM INCIDÊNCIA DA CONTRIBUIÇÃO', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('75', 'OPERAÇÃO DE AQUISIÇÃO POR SUBSTITUIÇÃO TRIBUTÁRIA', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('98', 'OUTRAS OPERAÇÕES DE ENTRADA', 0, true);",
            "Insert into cst_pis_cofins(codigo, descricao, aplicacao, ativo) values('99', 'OUTRAS OPERAÇÕES', 2, true);"
        };
    }
}