using System.Collections.Generic;

namespace ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes
{
    public interface IObterTransacoesPorContaUseCase
    {
        IReadOnlyCollection<TransacaoDto> Execute(int idConta);
    }
}
