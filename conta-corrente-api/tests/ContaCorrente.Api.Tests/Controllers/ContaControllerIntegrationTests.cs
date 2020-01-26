using ContaCorrente.Api.Tests._Fixtures;
using ContaCorrente.UseCases.Contracts.ContasCorrentes;
using ContaCorrente.UseCases.Contracts.ContasCorrentes.Transacoes;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ContaCorrente.Api.Tests.Controllers
{
    public class ContaControllerIntegrationTests : IClassFixture<ContaCorrenteWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ContaControllerIntegrationTests(ContaCorrenteWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_obter_saldo_da_conta_corrente()
        {
            var httpResponseMessage = await _client.GetAsync("/conta/2/saldo");

            httpResponseMessage.EnsureSuccessStatusCode();

            var jsonFromPostResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var dataResponse = JsonConvert.DeserializeObject<ContaDto>(jsonFromPostResponse);

            dataResponse.Should().NotBeNull();
        }

        [Fact]
        public async Task Deve_retornar_status_code_404_quando_conta_corrente_nao_existente_ao_obter_saldo()
        {
            var httpResponseMessage = await _client.GetAsync("/conta/4/saldo");

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Deve_obter_extrato_da_conta_corrente()
        {
            var httpResponseMessage = await _client.GetAsync("/conta/2/extrato");

            httpResponseMessage.EnsureSuccessStatusCode();

            var jsonFromPostResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var dataResponse = JsonConvert
                .DeserializeObject<IReadOnlyCollection<TransacaoDto>>(jsonFromPostResponse);

            dataResponse.Should().NotBeNull();
            dataResponse.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task Deve_retornar_status_code_404_quando_conta_corrente_nao_existente_ao_obter_extrato()
        {
            var httpResponseMessage = await _client.GetAsync("/conta/4/extrato");

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
