using ContaCorrente.CrossCutting;
using ContaCorrente.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Api.Tests._Fixtures
{
    public class TestStartup : ApplicationStartup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            using (var dbContext = app.ApplicationServices.GetService<ContaCorrenteDbContext>())
            {
                dbContext.SeedContaCorrenteInMemoryDb();
            }
        }
    }
}
