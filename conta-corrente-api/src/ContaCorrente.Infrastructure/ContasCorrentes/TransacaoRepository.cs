using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Domain.ContasCorrentes.Interfaces;
using ContaCorrente.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace ContaCorrente.Infrastructure.ContasCorrentes
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ContaCorrenteDbContext _dbContext;

        public TransacaoRepository(ContaCorrenteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Transacao transacao)
        {
            _dbContext.Transacoes.Add(transacao);
            _dbContext.SaveChanges();
        }

        public IReadOnlyCollection<Transacao> ObterPorConta(int idConta)
        {
            return _dbContext.Transacoes.Where(transacao => transacao.Conta.Id == idConta).ToList();
        }

        public Transacao ObterPorId(int id)
        {
            return _dbContext.Transacoes.Find(id);
        }
    }
}
