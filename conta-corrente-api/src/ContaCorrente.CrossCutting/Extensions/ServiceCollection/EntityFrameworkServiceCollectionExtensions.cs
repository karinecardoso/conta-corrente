using ContaCorrente.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.CrossCutting.Extensions.ServiceCollection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static void AddContaCorrenteDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<ContaCorrenteDbContext>(c =>
            {
                c.UseMySQL(
                    configuration.GetConnectionString("ContaCorrente"),
                    b => b.MigrationsAssembly(typeof(ContaCorrenteDbContext).Assembly.GetName().Name)
                );
            });
        }
    }
}
