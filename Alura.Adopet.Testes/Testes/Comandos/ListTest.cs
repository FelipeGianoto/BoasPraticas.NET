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
    public class ListTest
    {
        [Fact]
        public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
        {
            //Arrange
            List<Pet>? listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                              "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var httpClientPet = ApiServiceMockBuilder.GetMockList(listaDePet);

            //Act
            var retorno = await new Console.Comandos.List(httpClientPet.Object)
                .ExecutarAsync();

            //Assert
            var resultado = (SuccessWithPets)retorno.Successes[0];
            Assert.Single(resultado.Data);
        }
    }
}
