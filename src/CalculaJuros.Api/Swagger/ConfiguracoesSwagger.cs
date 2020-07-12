using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CalculaJuros.Api.Swagger
{
    public static class ConfiguracoesSwagger
    {
        public static void ConfigurarSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"); });
        }

        public static void InjetarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Cálculo de Juros Compostos",
                    Description = @"API para obtenção valores a partir do cálculo de juros compostos,
                        com propósito de uso em aplicações financeiras",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael Simonelli",
                        Email = "rafael.simonelli@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/carlos-rafael-simonelli-c-de-c-souza-54321a4a/"),
                    }
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "CalculaJuros.Api.xml"));
            });
        }
    }
}
