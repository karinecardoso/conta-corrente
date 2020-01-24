using ContaCorrente.Domain.ContasCorrentes;
using System;

namespace ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes
{
    public class TransacaoDto
    {
        public TransacaoDto() { }

        public TransacaoDto(Transacao transacao)
        {
            Id = transacao.Id;
            Tipo = transacao.Tipo;
            Valor = transacao.Valor;
            Data = transacao.Data;
            Descricao = transacao.Descricao;

            if (transacao.Conta != null)
            {
                IdConta = transacao.Conta.Id;
            }
        }

        public int Id { get; set; }

        public TipoTransacao Tipo { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public string Descricao { get; set; }

        public int IdConta { get; set; }
    }
}
