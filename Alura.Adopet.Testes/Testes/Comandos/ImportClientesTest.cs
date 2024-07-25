using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Testes.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Comandos
{
    public class ImportClientesTest
    {
        [Fact]
        public async Task QuandoClienteEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Cliente> listaDeClientes = new();
            var cliente = new Cliente(
                id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                nome: "André",
                email: "andre@email.org");
            listaDeClientes.Add(cliente);

            var leitorDeArquivo = LeitorDeArquivoMockBuilder.GetMock(listaDeClientes);

            var service = ApiServiceMockBuilder.GetMock<Cliente>();

            var import = new ImportClientes(service.Object, leitorDeArquivo.Object);

            //Act
            var resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsSuccess);
            var sucesso = (SuccessWithClientes)resultado.Successes[0];
            Assert.Equal("André", sucesso.Data.First().Nome);
        }
    }
}
