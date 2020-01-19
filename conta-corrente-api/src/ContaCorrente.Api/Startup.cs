using Autofac;
using ContaCorrente.CrossCutting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Api
{
    public class Startup
    {
        private IApplicationStartup _startup;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _startup = services.BuildServiceProvider().GetRequiredService<IApplicationStartup>();
            _startup.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _startup.Configure(app, env);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            _startup.ConfigureContainer(builder);
        }
    }
}
