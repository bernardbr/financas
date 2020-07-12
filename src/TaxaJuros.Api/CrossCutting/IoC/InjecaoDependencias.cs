using Microsoft.Extensions.DependencyInjection;
using TaxaJuros.Api.Dominio.Servicos;
using TaxaJuros.Api.Dominio.Servicos.Implementacoes;

namespace TaxaJuros.Api.CrossCutting.IoC
{
    public static class InjecaoDependencias
    {
        public static void AddServicoDominio(this IServiceCollection services)
        {
            services.AddScoped<IServicoTaxaJuros, ServicoTaxaJuros>();
        }
    }
}
