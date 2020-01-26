using ContaCorrente.CrossCutting;
using ContaCorrente.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContaCorrente.Api.Tests._Fixtures
{
    public class ContaCorrenteWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IApplicationStartup, TestStartup>();
                services.AddDbContextPool<ContaCorrenteDbContext>(options =>
                {
                    options.UseInMemoryDatabase("ContaCorrente");
                });
            });
        }
    }
}
