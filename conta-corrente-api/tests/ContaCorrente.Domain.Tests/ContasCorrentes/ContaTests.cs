using ContaCorrente.Domain.ContasCorrentes;
using FluentAssertions;
using Xunit;

namespace ContaCorrente.Domain.Tests.ContasCorrentes
{
    public class ContaTests
    {
        private readonly Conta _conta = new Conta
        {
            Id = 1,
            Agencia = 1,
            Numero = 12345,
            Digito = 6,
            Saldo = 100
        };

        [Fact]
        public void Deve_retornar_true_quando_conta_corrente_com_saldo_suficiente()
        {
            _conta.TemSaldoSuficiente(99).Should().BeTrue();
            _conta.TemSaldoSuficiente(100).Should().BeTrue();
        }

        [Fact]
        public void Deve_retornar_false_quando_conta_corrente_com_saldo_insuficiente()
        {
            _conta.TemSaldoSuficiente(101).Should().BeFalse();
            _conta.TemSaldoSuficiente(150).Should().BeFalse();
        }
    }
}
