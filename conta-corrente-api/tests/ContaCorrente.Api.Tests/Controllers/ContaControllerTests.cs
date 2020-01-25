using ContaCorrente.Api.Controllers;
using ContaCorrente.UseCases.Contracts.ContasCorrentes;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using Moq;
using Xunit;

namespace ContaCorrente.Api.Tests.Controllers
{
    public class ContaControllerTests
    {
        private readonly ContaDto _contaDto = new ContaDto
        {
            Id = 1,
            Agencia = 1,
            Numero = 12345,
            Digito = 6,
            Saldo = 100
        };

        private Mock<IObterContaUseCase> MockObterContaUseCase(ContaDto contaDto)
        {
            var mock = new Mock<IObterContaUseCase>();

            mock.Setup(x => x.Execute(It.IsAny<int>())).Returns(contaDto);

            return mock;
        }

        private Mock<IObterTransacoesPorContaUseCase> MockObterTransacoesPorContaUseCase() =>
            new Mock<IObterTransacoesPorContaUseCase>();

        [Fact]
        public void Deve_invocar_use_case_para_obter_conta_corrente()
        {
            var obterContaUseCaseMock = MockObterContaUseCase(_contaDto);
            var obterTransacoesPorContaUseCaseMock = MockObterTransacoesPorContaUseCase();

            var sut = new ContaController
            (
                obterContaUseCaseMock.Object,
                obterTransacoesPorContaUseCaseMock.Object
            );

            sut.GetSaldoConta(1);
            obterContaUseCaseMock.Verify(x => x.Execute(1), Times.Once);
        }

        [Fact]
        public void Deve_invocar_use_case_para_obter_transacoes_por_conta_corrente_quando_existente()
        {
            var obterContaUseCaseMock = MockObterContaUseCase(_contaDto);
            var obterTransacoesPorContaUseCaseMock = MockObterTransacoesPorContaUseCase();

            var sut = new ContaController
            (
                obterContaUseCaseMock.Object,
                obterTransacoesPorContaUseCaseMock.Object
            );

            sut.GetExtratoConta(1);
            obterContaUseCaseMock.Verify(x => x.Execute(1), Times.Once);
            obterTransacoesPorContaUseCaseMock.Verify(x => x.Execute(1), Times.Once);
        }

        [Fact]
        public void Nao_deve_invocar_use_case_para_obter_transacoes_por_conta_quando_nao_existente()
        {
            var obterContaUseCaseMock = MockObterContaUseCase(null);
            var obterTransacoesPorContaUseCaseMock = MockObterTransacoesPorContaUseCase();

            var sut = new ContaController
            (
                obterContaUseCaseMock.Object,
                obterTransacoesPorContaUseCaseMock.Object
            );

            sut.GetExtratoConta(1);
            obterContaUseCaseMock.Verify(x => x.Execute(1), Times.Once);
            obterTransacoesPorContaUseCaseMock.Verify(x => x.Execute(1), Times.Never);
        }
    }
}
