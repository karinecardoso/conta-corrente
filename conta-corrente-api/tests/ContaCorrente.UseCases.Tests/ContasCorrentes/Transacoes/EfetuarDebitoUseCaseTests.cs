using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.ContasCorrentes.Transacoes;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace ContaCorrente.UseCases.Tests.ContasCorrentes.Transacoes
{
    public class EfetuarDebitoUseCaseTests
    {
        private readonly Conta _contaMock = new Conta
        {
            Id = 1,
            Agencia = 1,
            Numero = 12345,
            Digito = 6,
            Saldo = 100
        };

        private readonly TransacaoDto _requestMock = new TransacaoDto
        {
            IdConta = 1,
            Valor = 50,
            Descricao = "Retirada",
            Tipo = TipoTransacao.Retirada
        };

        private Mock<IContaRepository> MockContaRepository(Conta conta)
        {
            var mock = new Mock<IContaRepository>();

            mock.Setup(x => x.ObterPorId(It.IsAny<int>())).Returns(conta);
            mock.Setup(x => x.Update(It.IsAny<Conta>()));

            return mock;
        }

        private Mock<ITransacaoRepository> MockTransacaoRepository()
        {
            var mock = new Mock<ITransacaoRepository>();

            mock.Setup(x => x.Add(It.IsAny<Transacao>()));

            return mock;
        }

        [Fact]
        public void Deve_efetuar_debito_na_conta_corrente()
        {
            var transacaoRepositoryMock = MockTransacaoRepository();
            var contaRepositoryMock = MockContaRepository(_contaMock);

            var sut = new EfetuarDebitoUseCase
            (
                transacaoRepositoryMock.Object,
                contaRepositoryMock.Object
            );

            sut.Execute(_requestMock);
            contaRepositoryMock.Verify(x => x.ObterPorId(1), Times.Once);
            contaRepositoryMock.Verify(x => x.Update(It.IsAny<Conta>()), Times.Once);
            transacaoRepositoryMock.Verify(x => x.Add(It.IsAny<Transacao>()), Times.Once());
        }

        [Fact]
        public void Deve_gerar_excecao_ao_efetuar_debito_em_uma_conta_corrente_nao_existente()
        {
            var transacaoRepositoryMock = MockTransacaoRepository();
            var contaRepositoryMock = MockContaRepository(null);

            var sut = new EfetuarDebitoUseCase
            (
                transacaoRepositoryMock.Object,
                contaRepositoryMock.Object
            );

            Action aceitarAction = () => sut.Execute(_requestMock);
            aceitarAction.Should().Throw<Exception>().WithMessage("Conta não encontrada.");
        }

        [Fact]
        public void Deve_gerar_excecao_ao_efetuar_debito_em_uma_conta_corrente_com_saldo_insuficiente()
        {
            var resquest = new TransacaoDto
            {
                IdConta = 1,
                Valor = 150,
                Descricao = "Retirada",
                Tipo = TipoTransacao.Retirada
            };

            var transacaoRepositoryMock = MockTransacaoRepository();
            var contaRepositoryMock = MockContaRepository(_contaMock);

            var sut = new EfetuarDebitoUseCase
            (
                transacaoRepositoryMock.Object,
                contaRepositoryMock.Object
            );

            Action aceitarAction = () => sut.Execute(resquest);
            aceitarAction.Should().Throw<Exception>().WithMessage("Saldo da conta insuficiente.");
        }
    }
}
