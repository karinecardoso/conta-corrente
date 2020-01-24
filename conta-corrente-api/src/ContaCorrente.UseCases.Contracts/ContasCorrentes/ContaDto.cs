using ContaCorrente.Domain.ContasCorrentes;

namespace ContaCorrente.UseCases.Contracts.ContasCorrentes
{
    public class ContaDto
    {
        public ContaDto(Conta conta)
        {
            Id = conta.Id;
            Agencia = conta.Id;
            Numero = conta.Numero;
            Digito = conta.Digito;
            Saldo = conta.Saldo;
        }

        public int Id { get; set; }

        public int Agencia { get; set; }

        public int Numero { get; set; }

        public int Digito { get; set; }

        public decimal Saldo { get; set; }
    }
}
