using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace AwsCs.Services.StorageApi.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Fundo Capital e Investidor",
                    Description = "Uma API Simples  de dados para Fundo Capital e Investidor",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Silva",
                        Email = "lucassilvadeoliveira@zipmail.com.br",
                        Url = new Uri("https://github.com/lucassilva-dev")
                    }
                });

                var filePath = Path.Combine(AppContext.BaseDirectory, "Uniciv.Api.xml");
                if (File.Exists(filePath))
                {
                    c.IncludeXmlComments(filePath);
                }

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "swagger";
                options.SwaggerEndpoint($"v1/swagger.json", "Aws NetCore - Storage");
            });

            return app;
        }

    }
}