using Autofac;
using ContaCorrente.Infrastructure.ContasCorrentes;
using ContaCorrente.UseCases.ContasCorrentes;
using ContaCorrente.UseCases.ContasCorrentes.Transacoes;

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

            builder.RegisterType<ObterContaUseCase>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<ObterTransacoesPorContaUseCase>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfetuarCreditoUseCase>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<EfetuarDebitoUseCase>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
