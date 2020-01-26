using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace ContaCorrente.CrossCutting.Extensions.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddContaCorrenteSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Conta Corrente API",
                        Version = "v1"
                    }
                );
                var filePath = Path.Combine
                (
                    PlatformServices.Default.Application.ApplicationBasePath,
                    "ContaCorrente.Api.xml"
                );
                c.IncludeXmlComments(filePath);
            });
        }
    }
}
