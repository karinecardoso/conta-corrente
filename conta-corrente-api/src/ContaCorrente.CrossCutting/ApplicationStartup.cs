using Autofac;
using ContaCorrente.CrossCutting.Api.Middlewares;
using ContaCorrente.CrossCutting.Extensions.ApplicationBuilder;
using ContaCorrente.CrossCutting.Extensions.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.CrossCutting
{
    public class ApplicationStartup : IApplicationStartup
    {
        private readonly IConfiguration _configuration;

        public ApplicationStartup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonFormatters()
                .AddApiExplorer();
            services.AddContaCorrenteDbContext(_configuration);
            services.AddContaCorrenteSwaggerGen();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureModules(_configuration);
        }

        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseContaCorrenteSeed();
            app.UseContaCorrenteSwagger();
            app.UseContaCorrenteCors();
            app.UseMiddleware<UnhandledExceptionMiddleware>();
            app.UseMvc();
        }
    }
}
