namespace TaxaJuros.Api.CrossCutting.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using TaxaJuros.Core.Dominio.Servicos.Implementacoes;
    using TaxaJuros.Core.Dominio.Servicos.Interfaces;

    public static class InjecaoDependencias
    {
        public static void InjetarDependenciasAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IServicoTaxaJuros, ServicoTaxaJuros>();
        }
    }
}