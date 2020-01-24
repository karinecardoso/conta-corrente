namespace ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes
{
    public interface IEfetuarCreditoUseCase
    {
        void Execute(TransacaoDto transacao);
    }
}
