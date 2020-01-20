using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.Infrastructure.Data;
using System.Linq;

namespace ContaCorrente.Infrastructure.ContasCorrentes
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaCorrenteDbContext _dbContext;

        public ContaRepository(ContaCorrenteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Conta conta)
        {
            _dbContext.ContasCorrentes.Add(conta);
            _dbContext.SaveChanges();
        }

        public void Update(Conta conta)
        {
            _dbContext.ContasCorrentes.Update(conta);
            _dbContext.SaveChanges();
        }

        public Conta ObterPorId(int id)
        {
            return _dbContext.ContasCorrentes.Find(id);
        }

        public void Seed()
        {
            if (_dbContext.ContasCorrentes.Count() < 1)
            {
                var conta = new Conta
                {
                    Id = 1,
                    Agencia = 1,
                    Numero = 12345,
                    Digito = 6
                };

                Add(conta);
            }
        }
    }
}
