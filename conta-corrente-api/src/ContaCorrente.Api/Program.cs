using Autofac.Extensions.DependencyInjection;
using ContaCorrente.CrossCutting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ContaCorrente.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<IApplicationStartup, ApplicationStartup>();
                    services.AddAutofac();
                })
                .UseStartup<Startup>();
    }
}
