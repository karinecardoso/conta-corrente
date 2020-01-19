using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.CrossCutting
{
    public interface IApplicationStartup
    {
        void ConfigureServices(IServiceCollection services);
        void ConfigureContainer(ContainerBuilder builder);
        void Configure(IApplicationBuilder app, IHostingEnvironment env);
    }
}
