using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Testes.Servicos
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            //Arrange
            var linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = linha.ConverteDoText();

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringNullaDeveLancarArgumentNullException()
        {
            //Arrange
            string linha = null;

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoText());
        }

        [Fact]
        public void QuandoStringVaziaDeveLancarArgumentException()
        {
            //Arrange
            string linha = string.Empty;

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoText());
        }

        [Fact]
        public void QuandoCamposInsuficientesDeveLancarArgumentException()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoText());
        }

        [Fact]
        public void QuandoGuidInvalidoDeveLancarArgumentException()
        {
            //Arrange
            string linha = "3123;Lima Limão;1";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoText());
        }

        [Fact]
        public void QuandoTipoInvalidoDeveLancarArgumentException()
        {
            //Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão; 3";

            //Act + Assert
            Assert.Throws<ArgumentException>(() => linha.ConverteDoText());
        }
    }
}
