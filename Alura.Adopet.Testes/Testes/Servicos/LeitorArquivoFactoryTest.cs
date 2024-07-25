using Alura.Adopet.Console.Servicos.Arquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Servicos
{
    public class LeitorArquivoFactoryTest
    {
        [Fact]
        public void QuandoExtensaoCsvDeveRetornarTipoAdequado()
        {
            // arrange
            string caminhoDoArquivo = "lista.csv";

            // act
            var leitor = LeitorDeArquivoFactory.CreatePetFrom(caminhoDoArquivo);

            // assert
            Assert.NotNull(leitor);
            Assert.IsType<PetsDoCsv>(leitor);
        }

        [Fact]
        public void QuandoExtensaoCsvDeveRetornarClientesDoCsv()
        {
            // arrange
            string caminhoDoArquivo = "lista.csv";

            // act
            var leitor = LeitorDeArquivoFactory.CreateClienteFrom(caminhoDoArquivo);

            // assert
            Assert.NotNull(leitor);
            Assert.IsType<ClientesDoCsv>(leitor);
        }

        [Fact]
        public void QuandoExtensaoJsonDeveRetornarClientesDoJson()
        {
            // arrange
            string caminhoDoArquivo = "lista.json";

            // act
            var leitor = LeitorDeArquivoFactory.CreateClienteFrom(caminhoDoArquivo);

            // assert
            Assert.NotNull(leitor);
            Assert.IsType<ClientesDoJson>(leitor);
        }

        [Fact]
        public void QuandoExtensaoJsonDeveRetornarTipoAdequado()
        {
            // arrange
            string caminhoDoArquivo = "qualquernome.json";

            // act
            var leitor = LeitorDeArquivoFactory.CreatePetFrom(caminhoDoArquivo);

            // assert
            Assert.NotNull(leitor);
            Assert.IsType<PetsDoJson>(leitor);
        }
    }
}
