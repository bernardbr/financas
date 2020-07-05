namespace CalculaJuros.Api.Clients.Implementacoes
{
    public class TaxaJurosClientOptions
    {
        public const string SessaoTaxaJurosClient = "TaxaJurosClient";

        public string Url { get; set; }
        public double DuracaoHandler { get; set; }
        public int TentativaMaximas { get; set; }
        public int LimiteCircuitBreaker { get; set; }
    }
}