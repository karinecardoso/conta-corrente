using ContaCorrente.Domain.ContasCorrentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaCorrente.Infrastructure.Data.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("contas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Agencia).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Digito).IsRequired();
            builder.Property(x => x.Saldo);
        }
    }
}
