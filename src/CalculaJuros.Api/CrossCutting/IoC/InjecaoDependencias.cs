using CalculaJuros.Api.Dominio.Servicos.Implementacoes;
using CalculaJuros.Api.Dominio.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaJuros.Api.CrossCutting.IoC
{
    public static class InjecaoDependencias
    {
        public static void InjetarDependenciasAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IServicoCalculoJurosCompostos, ServicoCalculoJurosCompostos>();
            services.AddScoped<IServicoCodigo, ServicoCodigo>();
        }
    }
}
