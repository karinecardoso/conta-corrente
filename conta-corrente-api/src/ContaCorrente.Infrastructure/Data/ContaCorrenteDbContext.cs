using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ContaCorrente.Infrastructure.Data
{
    public class ContaCorrenteDbContext : DbContext
    {
        public ContaCorrenteDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Conta> ContasCorrentes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaMapping());
            modelBuilder.ApplyConfiguration(new TransacaoMapping());
        }
    }
}
