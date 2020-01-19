using Autofac;
using Microsoft.AspNetCore.Http;

namespace ContaCorrente.CrossCutting.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
        }
    }
}
