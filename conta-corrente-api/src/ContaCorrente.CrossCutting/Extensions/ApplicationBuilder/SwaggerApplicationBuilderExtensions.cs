using Microsoft.AspNetCore.Builder;

namespace ContaCorrente.CrossCutting.Extensions.ApplicationBuilder
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static void UseContaCorrenteSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conta Corrente API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
