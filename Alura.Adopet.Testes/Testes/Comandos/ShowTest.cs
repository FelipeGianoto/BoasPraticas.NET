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
    public class ShowTest
    {
        [Fact]
        public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
        {
            //Arrange
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                              "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);
            var leitor = LeitorDeArquivoMockBuilder.GetMock(listaDePet);
            leitor.Setup(_ => _.RealizaLeitura());

            var show = new Show(leitor.Object);

            //Act
            var resultado = await show.ExecutarAsync();

            //Assert
            Assert.NotNull(resultado);
            var sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Equal("Exibição do arquivo realizada com sucesso!", sucesso.Message);
        }
    }
}
