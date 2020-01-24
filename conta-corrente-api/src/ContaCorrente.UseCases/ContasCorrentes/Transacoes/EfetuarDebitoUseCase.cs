using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using System;

namespace ContaCorrente.UseCases.ContasCorrentes.Transacoes
{
    public class EfetuarDebitoUseCase : IEfetuarDebitoUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;

        public EfetuarDebitoUseCase(
            ITransacaoRepository transacaoRepository,
            IContaRepository contaRepository
        )
        {
            _transacaoRepository = transacaoRepository;
            _contaRepository = contaRepository;
        }

        public void Execute(TransacaoDto transacao)
        {
            var conta = _contaRepository.ObterPorId(transacao.IdConta);

            if (conta == null)
            {
                throw new Exception("Conta não encontrada.");
            }

            if (!conta.TemSaldoSuficiente(transacao.Valor))
            {
                throw new Exception("Saldo da conta insuficiente.");
            }

            conta.Saldo -= transacao.Valor;

            _contaRepository.Update(conta);

            _transacaoRepository.Add(new Transacao
            {
                Tipo = transacao.Tipo,
                Valor = transacao.Valor,
                Data = DateTime.Now,
                Descricao = transacao.Descricao,
                Conta = conta
            });
        }
    }
}
