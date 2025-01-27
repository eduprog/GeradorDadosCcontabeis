namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class GruposConfiguracaoGridSistema : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnPessoas', 1,'Pessoas', 'GridViews/PivotGrids/DashBoards gerais relacionados ao cadastro de pessoas', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnProdutos', 2, 'Produtos', 'GridViews/PivotGrids/DashBoards gerais relacionados ao cadastro de produtos', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnMovimentos', 3, 'Movimentações', 'GridViews/PivotGrids/DashBoards gerais relacionados aos registros de movimentações de produtos', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnPagar', 5, 'Contas à Pagar', 'GridViews/PivotGrids/DashBoards gerais relacionados as contas à pagar', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnReceber', 4, 'Contas à Receber', 'GridViews/PivotGrids/DashBoards gerais relacionados as contas à receber', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnCaixa', 6, 'Caixa', 'GridViews/PivotGrids/DashBoards gerais relacionados as movimentações de caixa', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnDiversos', 99, 'Diversos', 'Outros GridViews/PivotGrids/DashBoards/não categorizados', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnFiscoContabilidade', 7, 'Fisco/Contabilidade', 'GridViews/PivotGrids/DashBoards gerais relacionados aos cadastros fiscais e contábeis', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnUsoInterno', 98, 'Uso Interno', 'GridViews/PivotGrids/DashBoards gerais utilizados internamente no sistema', 't', 't');"
        };
    }
}