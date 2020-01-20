using System.Collections.Generic;

namespace ContaCorrente.Domain.ContasCorrentes.Interfaces
{
    public interface ITransacaoRepository
    {
        void Add(Transacao transacao);

        Transacao ObterPorId(int id);

        IReadOnlyCollection<Transacao> ObterPorConta(int idConta);
    }
}
