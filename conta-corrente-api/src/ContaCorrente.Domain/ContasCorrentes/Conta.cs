using System.Collections.Generic;

namespace ContaCorrente.Domain.ContasCorrentes
{
    public class Conta
    {
        public int Id { get; set; }

        public int Agencia { get; set; }

        public int Numero { get; set; }

        public int Digito { get; set; }

        public decimal Saldo { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }

        public bool TemSaldoSuficiente(decimal valor)
        {
            return valor < Saldo;
        }
    }
}
