using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.ContasCorrentes.Transacoes;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ContaCorrente.UseCases.Tests.ContasCorrentes.Transacoes
{
    public class ObterTransacoesPorContaUseCaseTests
    {
        private Mock<ITransacaoRepository> MockTransacaoRepository(List<Transacao> transacoes)
        {
            var mock = new Mock<ITransacaoRepository>();

            mock.Setup(x => x.ObterPorConta(It.IsAny<int>())).Returns(transacoes);

            return mock;
        }

        [Fact]
        public void Deve_retornar_transacoes_da_conta_corrente_quando_existentes()
        {
            var conta = new Conta
            {
                Id = 1,
                Agencia = 1,
                Numero = 12345,
                Digito = 6,
                Saldo = 0
            };

            var transacoes = new List<Transacao>
            {
                new Transacao
                {
                    Id = 1,
                    Conta = conta,
                    Data = DateTime.Now,
                    Tipo = TipoTransacao.Deposito,
                    Valor = 100,
                    Descricao = "Deposito"
                },
                new Transacao
                {
                    Id = 2,
                    Conta = conta,
                    Data = DateTime.Now,
                    Tipo = TipoTransacao.Retirada,
                    Valor = 50,
                    Descricao = "Retirada"
                }
            };

            var transacaoRepositoryMock = MockTransacaoRepository(transacoes);

            var sut = new ObterTransacoesPorContaUseCase(transacaoRepositoryMock.Object);

            var result = sut.Execute(1);
            result.Should().NotBeEmpty();
            result.Count.Should().Be(transacoes.Count);
        }

        [Fact]
        public void Deve_retornar_lista_vazia_quando_conta_corrente_nao_possuir_transacoes()
        {
            var transacaoRepositoryMock = MockTransacaoRepository(null);

            var sut = new ObterTransacoesPorContaUseCase(transacaoRepositoryMock.Object);

            var result = sut.Execute(1);
            result.Should().BeEmpty();
        }
    }
}
