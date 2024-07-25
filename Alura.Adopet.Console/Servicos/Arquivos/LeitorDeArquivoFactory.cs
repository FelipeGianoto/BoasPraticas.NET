using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public static class LeitorDeArquivoFactory
    {
        public static ILeitorDeArquivos<Pet>? CreatePetFrom(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);
            switch (extensao)
            {
                case ".csv":
                    return new PetsDoCsv(caminhoArquivo);
                case ".json":
                    return new PetsDoJson(caminhoArquivo);
                default: return null;
            }
        }

        public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);
            switch (extensao)
            {
                case ".csv":
                    return new ClientesDoCsv(caminhoArquivo);
                case ".json":
                    return new ClientesDoJson(caminhoArquivo);
                default: return null;
            }
        }
    }
}
