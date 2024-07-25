using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Moq;

namespace Alura.Adopet.Testes.TestesDeIntegracao.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<PetsDoCsv> GetMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<PetsDoCsv>(MockBehavior.Default,
                It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}
