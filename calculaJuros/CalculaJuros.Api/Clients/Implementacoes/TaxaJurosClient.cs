namespace CalculaJuros.Api.Clients.Implementacoes
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using CalculaJuros.Api.Clients.Contratos;
    using CalculaJuros.Api.Clients.Interfaces;

    public class TaxaJurosClient : ITaxaJurosClient
    {
        private readonly HttpClient _httpClient;

        public TaxaJurosClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> ObterTaxaJuros()
        {
            var response = await _httpClient.GetStringAsync("/api/v1/taxaJuros");     
            var retorno = JsonSerializer.Deserialize<ContratoRetornoTaxaJuros>(response);
            return retorno.taxaJuros;
        }
    }
}