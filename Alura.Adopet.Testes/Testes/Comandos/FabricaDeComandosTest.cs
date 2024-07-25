using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Comandos
{
    public class FabricaDeComandosTest
    {
        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] args = { "import", "lista.csv" };

            //Act
            var comando = ComandosFacotry.CriarComando(args);

            //Assert
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoList()
        {
            //Arrange
            string[] args = { "list", "lista.csv" };

            //Act
            var comando = ComandosFacotry.CriarComando(args);

            //Assert
            Assert.IsType<List>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNulo()
        {
            //Arrange
            string[] args = { "inválido", "lista.csv" };

            //Act
            var comando = ComandosFacotry.CriarComando(args);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
        {
            //Arrange
            //Act
            var comando = ComandosFacotry.CriarComando(null);

            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosDeveRetornarNulo()
        {
            //Arrange
            string[] args = { };

            //Act
            var comando = ComandosFacotry.CriarComando(args);

            //Assert
            Assert.Null(comando);
        }
    }
}
