using Autofac;
using ContaCorrente.Infrastructure.ContasCorrentes;

namespace ContaCorrente.CrossCutting.Modules
{
    public class ContasCorrentesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContaRepository>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<TransacaoRepository>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
