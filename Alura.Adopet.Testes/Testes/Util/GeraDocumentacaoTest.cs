using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Util
{
    public class GeraDocumentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            //Arrange
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

            //Act
            Dictionary<string, DocComando> dicionario =
                  DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

            //Assert            
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(5, dicionario.Count);
        }

        [Theory]
        [InlineData("help", true)]
        [InlineData("show", true)]
        [InlineData("list", true)]
        [InlineData("import", true)]
        [InlineData("import-clientes", true)]
        [InlineData("lixo", false)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        public void DadaInstrucaoValidaDeveExistirNoDicionario(string instrucao, bool valido)
        {
            //Arrange
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

            //Act
            Dictionary<string, DocComando> dicionario =
                  DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

            //Assert            
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(valido, dicionario.ContainsKey(instrucao));
        }
    }
}
