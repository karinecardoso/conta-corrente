namespace ContaCorrente.Domain.ContasCorrentes.Interfaces
{
    public interface IContaRepository
    {
        void Add(Conta conta);

        void Update(Conta conta);

        Conta ObterPorId(int id);

        void Seed();
    }
}
