using System;

namespace ContaCorrente.Domain.ContasCorrentes
{
    public class Transacao
    {
        public int Id { get; set; }

        public TipoTransacao Tipo { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
