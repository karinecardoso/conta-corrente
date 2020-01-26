using ContaCorrente.Api.Controllers.Requests;
using ContaCorrente.Api.Tests._Fixtures;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Api.Tests.Controllers
{
    public class TransacaoControllerIntegrationTests : IClassFixture<ContaCorrenteWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public TransacaoControllerIntegrationTests(ContaCorrenteWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        private StringContent SerializeRequest(TransacaoRequest request)
        {
            var content = JsonConvert.SerializeObject(request);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }

        [Fact]
        public async Task Deve_efetuar_deposito_na_conta_corrente()
        {
            var request = new TransacaoRequest { IdConta = 2, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/deposito", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task retornar_status_code_500_quando_conta_corrente_nao_existente_ao_efetuar_deposito()
        {
            var request = new TransacaoRequest { IdConta = 5, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/deposito", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Deve_efetuar_retirada_na_conta_corrente()
        {
            var request = new TransacaoRequest { IdConta = 2, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/retirada", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task retornar_status_code_500_quando_conta_corrente_nao_existente_ao_efetuar_retirada()
        {
            var request = new TransacaoRequest { IdConta = 5, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/retirada", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task retornar_status_code_500_quando_saldo_insuficiente_ao_efetuar_retirada()
        {
            var request = new TransacaoRequest { IdConta = 2, Valor = 1000 };

            var httpResponseMessage = await _client.PostAsync("/conta/retirada", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Deve_efetuar_pagamento_na_conta_corrente()
        {
            var request = new TransacaoRequest { IdConta = 3, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/pagamento", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.Accepted);
        }

        [Fact]
        public async Task retornar_status_code_500_quando_conta_corrente_nao_existente_ao_efetuar_pagamento()
        {
            var request = new TransacaoRequest { IdConta = 5, Valor = 100 };

            var httpResponseMessage = await _client.PostAsync("/conta/pagamento", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task retornar_status_code_500_quando_saldo_insuficiente_ao_efetuar_pagamento()
        {
            var request = new TransacaoRequest { IdConta = 3, Valor = 1000 };

            var httpResponseMessage = await _client.PostAsync("/conta/pagamento", SerializeRequest(request));

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
