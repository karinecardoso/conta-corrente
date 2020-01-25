using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.ContasCorrentes;
using FluentAssertions;
using Moq;
using Xunit;

namespace ContaCorrente.UseCases.Tests.ContasCorrentes
{
    public class ObterContaUseCaseTests
    {
        private Mock<IContaRepository> MockContaRepository(Conta conta)
        {
            var mock = new Mock<IContaRepository>();

            mock.Setup(x => x.ObterPorId(It.IsAny<int>())).Returns(conta);

            return mock;
        }

        [Fact]
        public void Deve_retornar_conta_corrente_quando_existente()
        {
            var conta = new Conta
            {
                Id = 1,
                Agencia = 1,
                Numero = 12345,
                Digito = 6,
                Saldo = 0
            };

            var contaRepositoryMock = MockContaRepository(conta);

            var sut = new ObterContaUseCase(contaRepositoryMock.Object);

            var result = sut.Execute(1);
            result.Should().NotBeNull();
        }

        [Fact]
        public void Deve_retornar_null_quando_conta_corrente_nao_existente()
        {
            var contaRepositoryMock = MockContaRepository(null);

            var sut = new ObterContaUseCase(contaRepositoryMock.Object);

            var result = sut.Execute(1);
            result.Should().BeNull();
        }
    }
}
