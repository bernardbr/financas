namespace TaxaJuros.Api.Swagger
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    
    public static class ConfiguracoesSwagger
    {
        public static void InjetarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Taxa de Juros",
                    Description = @"API para obtenção de taxa de juros, 
                        com propósito de uso em aplicações financeiras",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Simonelli",
                        Email = "rafael.simonelli@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/carlos-rafael-simonelli-c-de-c-souza-54321a4a/"),
                    }
                });               

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "TaxaJuros.Api.xml"));
            });
        }

        public static void ConfigurarSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
        }
    }
}