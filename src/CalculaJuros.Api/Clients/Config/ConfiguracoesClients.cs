using CalculaJuros.Api.Clients.Implementacoes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace CalculaJuros.Api.Clients.Config
{
    public static class ConfiguracoesClients
    {
        public static void ConfigurarClientsHttp(this IServiceCollection services, IConfiguration config)
        {
            ConfigurarTaxaJurosClient(services, config);
        }

        private static void ConfigurarTaxaJurosClient(IServiceCollection services, IConfiguration config)
        {
            var configTaxaJurosClient = config
                .GetSection(TaxaJurosClientOptions.SESSAO_TAXA_JUROS_CLIENT)
                .Get<TaxaJurosClientOptions>();

            services
                .AddHttpClient<ITaxaJurosClient, TaxaJurosClient>(c =>
                    c.BaseAddress = new Uri(configTaxaJurosClient.Url))
                .SetHandlerLifetime(TimeSpan.FromMinutes(configTaxaJurosClient.DuracaoHandler))
                .AddPolicyHandler(ObterPoliticaRetryTaxaJuros(configTaxaJurosClient.TentativaMaximas))
                .AddPolicyHandler(ObterPoliticaDeCircuitBreakerTaxaJuros(configTaxaJurosClient.LimiteCircuitBreaker));
        }

        private static IAsyncPolicy<HttpResponseMessage> ObterPoliticaDeCircuitBreakerTaxaJuros(
            int limiteCircuitBreaker)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(limiteCircuitBreaker, TimeSpan.FromMinutes(1));
        }

        private static IAsyncPolicy<HttpResponseMessage> ObterPoliticaRetryTaxaJuros(int tentativas)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(response => !response.IsSuccessStatusCode)
                .WaitAndRetryAsync(tentativas,
                    tentativa => TimeSpan.FromSeconds(Math.Pow(2, tentativa)));
        }
    }
}
