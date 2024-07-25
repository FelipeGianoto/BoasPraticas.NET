using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Testes.Builder
{
    internal static class LeitorDeArquivoMockBuilder
    {
        public static Mock<ILeitorDeArquivos<T>> GetMock<T>(List<T> lista)
        {
            var leitorDeArquivo = new Mock<ILeitorDeArquivos<T>>(MockBehavior.Default);

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(lista);

            return leitorDeArquivo;
        }
    }
}
