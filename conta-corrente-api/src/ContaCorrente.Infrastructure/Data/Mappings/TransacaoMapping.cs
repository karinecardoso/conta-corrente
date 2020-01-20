using ContaCorrente.Domain.ContasCorrentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaCorrente.Infrastructure.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Descricao);

            builder.HasOne(x => x.Conta).WithMany(x => x.Transacoes);
        }
    }
}
