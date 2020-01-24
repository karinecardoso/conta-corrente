using ContaCorrente.UseCases.Contracts.ContasCorrentes;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace ContaCorrente.Api.Controllers
{
    [Produces("application/json")]
    [Route("conta")]
    public class ContaController : Controller
    {
        private readonly IObterContaUseCase _obterContaUseCase;
        private readonly IObterTransacoesPorContaUseCase _obterTransacoesPorContaUseCase;

        public ContaController
        (
            IObterContaUseCase obterContaUseCase,
            IObterTransacoesPorContaUseCase obterTransacoesPorContaUseCase
        )
        {
            _obterContaUseCase = obterContaUseCase;
            _obterTransacoesPorContaUseCase = obterTransacoesPorContaUseCase;
        }

        /// <summary>
        /// Obtem as informações da conta corrente
        /// </summary>
        /// <param name="idConta"></param>
        /// <response code="200">Retorna as informações da conta corrente</response>
        /// <response code="404">Caso a conta corrente não exista</response>
        [HttpGet("{idConta}/saldo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetConta(int idConta)
        {
            var conta = _obterContaUseCase.Execute(idConta);

            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            return Ok(conta);
        }

        /// <summary>
        /// Obtem o extrato da conta corrente
        /// </summary>
        /// <param name="idConta"></param>
        /// <response code="200">Retorna o extrato da conta corrente</response>
        /// <response code="404">Caso a conta corrente não exista</response>
        [HttpGet("{idConta}/extrato")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetExtratoConta(int idConta)
        {
            var conta = _obterContaUseCase.Execute(idConta);

            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            return Ok(_obterTransacoesPorContaUseCase.Execute(idConta));
        }

    }
}