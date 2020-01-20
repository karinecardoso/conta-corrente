using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ContaCorrente.CrossCutting.Extensions.ApplicationBuilder
{
    public static class SeedApplicationBuilderExtensions
    {
        public static void UseContaCorrenteSeed(this IApplicationBuilder app)
        {
            IServiceProvider services = app.ApplicationServices;

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<IContaRepository>();
                db.Seed();
            }
        }
    }
}
