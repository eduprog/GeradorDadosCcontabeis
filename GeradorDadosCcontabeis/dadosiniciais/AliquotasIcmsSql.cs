namespace GeradorDadosCcontabeis.dadosiniciais
{
    public class AliquotasIcmsSql : ISql
    {
        public ICollection<string> Sql { get; set; } = new List<string>
        {
            "INSERT INTO aliq_icms(aliquota, descricao, ativo) VALUES (0, '', true);"
        };
    }
}