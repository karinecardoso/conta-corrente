using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.UseCases.Contracts.ContasCorrentes;

namespace ContaCorrente.UseCases.ContasCorrentes
{
    public class ObterContaUseCase : IObterContaUseCase
    {
        private readonly IContaRepository _contaRepository;

        public ObterContaUseCase(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public ContaDto Execute(int id)
        {
            var conta = _contaRepository.ObterPorId(id);

            if (conta == null)
            {
                return null;
            }

            return new ContaDto(conta);
        }
    }
}
