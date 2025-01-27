namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class GruposConfiguracaoGridSistema : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnPessoas', 1,'Pessoas', 'GridViews/PivotGrids/DashBoards gerais relacionados ao cadastro de pessoas', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnProdutos', 2, 'Produtos', 'GridViews/PivotGrids/DashBoards gerais relacionados ao cadastro de produtos', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnMovimentos', 3, 'Movimenta��es', 'GridViews/PivotGrids/DashBoards gerais relacionados aos registros de movimenta��es de produtos', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnPagar', 5, 'Contas � Pagar', 'GridViews/PivotGrids/DashBoards gerais relacionados as contas � pagar', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnReceber', 4, 'Contas � Receber', 'GridViews/PivotGrids/DashBoards gerais relacionados as contas � receber', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnCaixa', 6, 'Caixa', 'GridViews/PivotGrids/DashBoards gerais relacionados as movimenta��es de caixa', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnDiversos', 99, 'Diversos', 'Outros GridViews/PivotGrids/DashBoards/n�o categorizados', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnFiscoContabilidade', 7, 'Fisco/Contabilidade', 'GridViews/PivotGrids/DashBoards gerais relacionados aos cadastros fiscais e cont�beis', 't', 'f');",
            "INSERT INTO grupo_conf_grid_sis (nome_menu, ordem_menu, nome, descricao_hint, ativo, uso_interno) VALUES ('mnUsoInterno', 98, 'Uso Interno', 'GridViews/PivotGrids/DashBoards gerais utilizados internamente no sistema', 't', 't');"
        };
    }
}