using ContaCorrente.Api.Controllers;
using ContaCorrente.Api.Controllers.Requests;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using Moq;
using Xunit;

namespace ContaCorrente.Api.Tests.Controllers
{
    public class TransacaoControllerTests
    {
        private readonly TransacaoRequest _request = new TransacaoRequest
        {
            IdConta = 1,
            Valor = 100,
            Descricao = "Transacao"
        };

        private Mock<IEfetuarCreditoUseCase> MockEfetuarCreditoUseCase() =>
            new Mock<IEfetuarCreditoUseCase>();

        private Mock<IEfetuarDebitoUseCase> MockEfetuarDebitoUseCase() =>
            new Mock<IEfetuarDebitoUseCase>();

        [Fact]
        public void Deve_invocar_use_case_para_efetuar_credito_em_conta_corrente_quando_deposito()
        {
            var efetuarCreditoUseCaseMock = MockEfetuarCreditoUseCase();
            var efetuarDebitoUseCaseMock = MockEfetuarDebitoUseCase();

            var sut = new TransacaoController
            (
                efetuarCreditoUseCaseMock.Object,
                efetuarDebitoUseCaseMock.Object
            );

            sut.PostEfetuarDepositoConta(_request);
            efetuarCreditoUseCaseMock.Verify(x => x.Execute(It.IsAny<TransacaoDto>()), Times.Once);
        }

        [Fact]
        public void Deve_invocar_use_case_para_efetuar_debito_em_conta_corrente_quando_retirada()
        {
            var efetuarCreditoUseCaseMock = MockEfetuarCreditoUseCase();
            var efetuarDebitoUseCaseMock = MockEfetuarDebitoUseCase();

            var sut = new TransacaoController
            (
                efetuarCreditoUseCaseMock.Object,
                efetuarDebitoUseCaseMock.Object
            );

            sut.PostEfetuarRetiradaConta(_request);
            efetuarDebitoUseCaseMock.Verify(x => x.Execute(It.IsAny<TransacaoDto>()), Times.Once);
        }

        [Fact]
        public void Deve_invocar_use_case_para_efetuar_debito_em_conta_corrente_quando_pagamento()
        {
            var efetuarCreditoUseCaseMock = MockEfetuarCreditoUseCase();
            var efetuarDebitoUseCaseMock = MockEfetuarDebitoUseCase();

            var sut = new TransacaoController
            (
                efetuarCreditoUseCaseMock.Object,
                efetuarDebitoUseCaseMock.Object
            );

            sut.PostEfetuarPagamentoConta(_request);
            efetuarDebitoUseCaseMock.Verify(x => x.Execute(It.IsAny<TransacaoDto>()), Times.Once);
        }
    }
}
