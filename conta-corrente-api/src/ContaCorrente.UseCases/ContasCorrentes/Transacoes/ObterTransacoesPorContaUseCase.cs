using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using System.Collections.Generic;
using System.Linq;

namespace ContaCorrente.UseCases.ContasCorrentes.Transacoes
{
    public class ObterTransacoesPorContaUseCase : IObterTransacoesPorContaUseCase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public ObterTransacoesPorContaUseCase(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public IReadOnlyCollection<TransacaoDto> Execute(int idConta)
        {
            var transacoes = _transacaoRepository.ObterPorConta(idConta);
            return transacoes?.Select(x => new TransacaoDto(x)).ToList() ?? new List<TransacaoDto>();
        }
    }
}
