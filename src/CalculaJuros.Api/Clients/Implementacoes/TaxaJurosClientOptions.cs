namespace CalculaJuros.Api.Clients.Implementacoes
{
    public class TaxaJurosClientOptions
    {
        public const string SESSAO_TAXA_JUROS_CLIENT = "TaxaJurosClient";

        public double DuracaoHandler { get; set; }
        public int LimiteCircuitBreaker { get; set; }
        public int TentativaMaximas { get; set; }
        public string Url { get; set; }
    }
}
