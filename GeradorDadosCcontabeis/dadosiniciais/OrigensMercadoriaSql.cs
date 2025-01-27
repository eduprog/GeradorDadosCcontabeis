namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class OrigensMercadoriaSql : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('0', 'NACIONAL - EXCETO AS INDICADAS NOS CÓDIGOS 3 A 5', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('1', 'ESTRANGEIRA – IMPORTAÇÃO DIRETA, EXCETO A INDICADA NO CÓDIGO 6', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('2', 'ESTRANGEIRA – ADQUIRIDA NO MERCADO INTERNO, EXCETO A INDICADA NO CÓDIGO 7', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('3', 'NACIONAL - MERCADORIA OU BEM COM CONTEÚDO DE IMPORTAÇÃO SUPERIOR A 40% E INFERIOR OU IGUAL A 70%', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('4', 'NACIONAL - CUJA PRODUЗГO TENHA SIDO FEITA EM CONFORMIDADE COM OS PROCESSOS PRODUTIVOS BÁSICOS DE QUE TRATAM O DECRETO-LEI NЄ 288/67, E AS LEIS Nº 8.248/91, 8.387/91, 10.176/01 E 11.484/07', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('5', 'NACIONAL - MERCADORIA OU BEM COM CONTEÚDO DE IMPORTAÇÃO INFERIOR OU IGUAL A 40% (QUARENTA POR CENTO)', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('6', 'ESTRANGEIRA – IMPORTAÇÃO DIRETA, SEM SIMILAR NACIONAL, CONSTANTE EM LISTA DE RESOLUÇÃO CAMEX', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('7', 'ESTRANGEIRA – ADQUIRIDA NO MERCADO INTERNO, SEM SIMILAR NACIONAL, CONSTANTE EM LISTA DE RESOLUÇÃO CAMEX', TRUE);",
            "INSERT INTO origem_cst (codigo, descricao, ativo) VALUES ('8', 'NACIONAL - MERCADORIA OU BEM COM CONTEÚDO DE IMPORTAÇÃO SUPERIOR A 70%', TRUE);"
        };
    }
}