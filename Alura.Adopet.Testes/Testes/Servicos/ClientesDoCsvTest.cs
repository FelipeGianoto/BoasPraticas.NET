using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Servicos
{
    public class ClientesDoCsvTest : IDisposable
    {
        private string caminhoArquivo;
        public ClientesDoCsvTest()
        {
            //Setup
            string linha = "456b24f4-19e2-0192-845d-4a80e8854a41;Mariana;mari@email.com;1121221";
            File.WriteAllText("lista.csv", linha);
            caminhoArquivo = Path.GetFullPath("lista.csv");
        }

        [Fact]
        public void QuandoArquivoExistenteDeveRetornarUmaListaDeClientes()
        {
            //Arrange            
            //Act
            var listaDeClientes = new ClientesDoCsv(caminhoArquivo).RealizaLeitura()!;
            //Assert
            Assert.NotNull(listaDeClientes);
            Assert.Single(listaDeClientes);
            Assert.IsType<List<Cliente>?>(listaDeClientes);
        }

        //[Fact]
        //public void QuandoArquivoNaoExistenteDeveRetornarNulo()
        //{
        //    //Arrange            
        //    //Act
        //    var listaDeClientes = new LeitorDeArquivoCsv("").RealizaLeitura();
        //    //Assert
        //    Assert.Null(listaDeClientes);
        //}

        //[Fact]
        //public void QuandoArquivoForNuloDeveRetornarNulo()
        //{
        //    //Arrange            
        //    //Act
        //    var listaDeClientes = new LeitorDeArquivoCsv(null).RealizaLeitura();
        //    //Assert
        //    Assert.Null(listaDeClientes);
        //}

        public void Dispose()
        {
            //ClearDown
            File.Delete(caminhoArquivo);
        }
    }
}
