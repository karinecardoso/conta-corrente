namespace ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes
{
    public interface IEfetuarDebitoUseCase
    {
        void Execute(TransacaoDto transacao);
    }
}
