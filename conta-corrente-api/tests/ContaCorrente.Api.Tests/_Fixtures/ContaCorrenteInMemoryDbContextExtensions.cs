using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Infrastructure.Data;
using System;
using System.Linq;

namespace ContaCorrente.Api.Tests._Fixtures
{
    public static class ContaCorrenteInMemoryDbContextExtensions
    {
        public static void SeedContaCorrenteInMemoryDb(this ContaCorrenteDbContext dbContext)
        {
            if (dbContext.Transacoes.Count() < 1)
            {
                var contas = new Conta[]
                {
                    new Conta { Id = 2, Agencia = 1, Numero = 12345, Digito = 6, Saldo = 650 },
                    new Conta { Id = 3, Agencia = 1, Numero = 45678, Digito = 9, Saldo = 653.01M }
                };

                var transacoes = new Transacao[]
                {
                    new Transacao { Conta = contas[0], Data = DateTime.Now, Tipo = TipoTransacao.Deposito, Valor = 1000 },
                    new Transacao { Conta = contas[0], Data = DateTime.Now, Tipo = TipoTransacao.Retirada, Valor = 350 },
                    new Transacao { Conta = contas[1], Data = DateTime.Now, Tipo = TipoTransacao.Deposito, Valor = 800 },
                    new Transacao { Conta = contas[1], Data = DateTime.Now, Tipo = TipoTransacao.Pagamento, Valor = 146.99M }
                };

                dbContext.ContasCorrentes.Add(contas[1]);
                dbContext.Transacoes.AddRange(transacoes);

                dbContext.SaveChanges();
            }
        }
    }
}
