namespace CalculaJuros.Api.CrossCutting.IoC
{
    using CalculaJuros.Core.Dominio.Servicos.Implementacoes;
    using CalculaJuros.Core.Dominio.Servicos.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class InjecaoDependencias
    {
        public static void InjetarDependenciasAplicacao(this IServiceCollection services)
        {
            services.AddScoped<IServicoCalculoJurosCompostos, ServicoCalculoJurosCompostos>();
            services.AddScoped<IServicoCodigo, ServicoCodigo>();
        }
    }
}