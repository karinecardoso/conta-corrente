using System.ComponentModel.DataAnnotations;

namespace ContaCorrente.Api.Controllers.Requests
{
    public class TransacaoRequest
    {
        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int IdConta { get; set; }

        public string Descricao { get; set; }
    }

}
