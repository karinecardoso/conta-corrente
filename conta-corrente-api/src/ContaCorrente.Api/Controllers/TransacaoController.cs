﻿using ContaCorrente.Api.Controllers.Requests;
using ContaCorrente.Domain.ContasCorrentes;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace ContaCorrente.Api.Controllers
{
    [Produces("application/json")]
    [Route("conta")]
    public class TransacaoController : Controller
    {
        private readonly IEfetuarCreditoUseCase _efetuarCreditoUseCase;
        private readonly IEfetuarDebitoUseCase _efetuarDebitoUseCase;

        public TransacaoController
        (
            IEfetuarCreditoUseCase efetuarCreditoUseCase,
            IEfetuarDebitoUseCase efetuarDebitoUseCase
        )
        {
            _efetuarCreditoUseCase = efetuarCreditoUseCase;
            _efetuarDebitoUseCase = efetuarDebitoUseCase;
        }

        /// <summary>
        /// Efetua um deposito na conta corrente
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     POST /conta/deposito
        ///     {
        ///         "Valor": 100,
        ///         "IdConta": 1,
        ///         "Descricao": "Deposito"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="202">Caso o deposito seja efetuado</response>
        /// <response code="500">Falha ao efetuar deposito na conta corrente</response>
        [HttpPost("deposito")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        public IActionResult PostEfetuarDepositoConta
        (
            [FromBody] TransacaoRequest request
        )
        {
            _efetuarCreditoUseCase.Execute(new TransacaoDto
            {
                Tipo = TipoTransacao.Deposito,
                Valor = request.Valor,
                IdConta = request.IdConta,
                Descricao = request.Descricao
            });

            return Accepted();
        }

        /// <summary>
        /// Efetua uma retirada na conta corrente
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     POST /conta/retirada
        ///     {
        ///         "Valor": 100,
        ///         "IdConta": 1,
        ///         "Descricao": "Retirada"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="202">Caso a retirada seja efetuada</response>
        /// <response code="500">Falha ao efetuar retirada na conta corrente</response>
        [HttpPost("retirada")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        public IActionResult PostEfetuarRetiradaConta
        (
            [FromBody] TransacaoRequest request
        )
        {
            _efetuarDebitoUseCase.Execute(new TransacaoDto
            {
                Tipo = TipoTransacao.Retirada,
                Valor = request.Valor,
                IdConta = request.IdConta,
                Descricao = request.Descricao
            });

            return Accepted();
        }

        /// <summary>
        /// Efetua um pagamento na conta corrente
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     POST /conta/pagamento
        ///     {
        ///         "Valor": 100,
        ///         "IdConta": 1,
        ///         "Descricao": "Pagamento"
        ///     }
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="202">Caso o pagamento seja efetuado</response>
        /// <response code="500">Falha ao efetuar pagamento na conta corrente</response>
        [HttpPost("pagamento")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        public IActionResult PostEfetuarPagamentoConta
        (
            [FromBody] TransacaoRequest request
        )
        {
            _efetuarDebitoUseCase.Execute(new TransacaoDto
            {
                Tipo = TipoTransacao.Pagamento,
                Valor = request.Valor,
                IdConta = request.IdConta,
                Descricao = request.Descricao
            });

            return Accepted();
        }
    }
}