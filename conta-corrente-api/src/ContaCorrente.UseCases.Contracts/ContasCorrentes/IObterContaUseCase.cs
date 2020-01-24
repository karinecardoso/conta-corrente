namespace ContaCorrente.UseCases.Contracts.ContasCorrentes
{
    public interface IObterContaUseCase
    {
        ContaDto Execute(int id);
    }
}
