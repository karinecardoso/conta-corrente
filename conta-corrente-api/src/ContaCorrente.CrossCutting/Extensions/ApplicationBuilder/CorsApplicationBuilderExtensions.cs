using Microsoft.AspNetCore.Builder;

namespace ContaCorrente.CrossCutting.Extensions.ApplicationBuilder
{
    public static class CorsApplicationBuilderExtensions
    {
        public static void UseContaCorrenteCors(this IApplicationBuilder app)
        {
            app.UseCors(builder
                => builder
                    .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());
        }
    }
}
