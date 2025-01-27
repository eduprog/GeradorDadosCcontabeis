namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class EstadosSql : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (12,30,'Acre','AC',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (27,30,'Alagoas','AL',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (13,30,'Amazonas','AM',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (16,30,'Amapá','AP',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (29,30,'Bahia','BA',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (53,30,'Distrito Federal','DF',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (23,30,'Ceará','CE',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (32,30,'Espírito Santo','ES',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (52,30,'Goiás','GO',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (21,30,'Maranhão','MA',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (51,30,'Mato Grosso','MT',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (50,30,'Mato Grosso do Sul','MS',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (31,30,'Minas Gerais','MG',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (15,30,'Pará','PA',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (25,30,'Paraíba','PB',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (26,30,'Pernambuco','PE',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (41,30,'Paraná','PR',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (22,30,'Piauí','PI',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (33,30,'Rio de Janeiro','RJ',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (24,30,'Rio Grande do Norte','RN',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (43,30,'Rio Grande do Sul','RS',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (14,30,'Roraima','RR',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (11,30,'Rondônia','RO',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (42,30,'Santa Catarina','SC',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (35,30,'São Paulo','SP',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (28,30,'Sergipe','SE',true);",
            "INSERT INTO estado (codigo_ibge,id_pais,nome,sigla,ativo) VALUES (17,30,'Tocantis','TO',true);"
        };
    }
}
