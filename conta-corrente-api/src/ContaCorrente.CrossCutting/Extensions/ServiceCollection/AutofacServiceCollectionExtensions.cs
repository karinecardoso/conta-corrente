using Autofac;
using ContaCorrente.CrossCutting.Modules;
using Microsoft.Extensions.Configuration;

namespace ContaCorrente.CrossCutting.Extensions.ServiceCollection
{
    public static class AutofacServiceCollectionExtensions
    {
        public static void ConfigureModules(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterAssemblyModules(typeof(ApplicationModule).Assembly);
        }
    }
}
