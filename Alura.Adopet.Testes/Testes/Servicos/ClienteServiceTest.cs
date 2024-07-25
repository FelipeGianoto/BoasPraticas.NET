using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Testes.Testes.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Servicos
{
    public class ClienteServiceTest
    {
        [Fact]
        public async Task RespostaComClientesDeveRetornarListaNaoVazia()
        {
            //Arrange
            var httpClient = HttpClientMockBuilder
                .GetMock(@"
                [
                  {
                    ""id"": ""ed48920c-5adb-4684-9b8f-ba8a94775a11"",
                    ""nome"": ""Fulano de Tal"",
                    ""email"": ""fulano@example.org""
                  },
                  {
                    ""id"": ""456b24f4-19e2-4423-845d-4a80e8854a41"",
                    ""nome"": ""José Silva"",
                    ""email"": ""silva@example.org"",
                    ""cpf"": ""1312312""
                  }
                ]
        ");
            var service = new ClienteService(httpClient.Object);

            //Act
            var lista = await service.ListAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }
    }
}
