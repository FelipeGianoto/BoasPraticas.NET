using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public abstract class LeitorDeArquivoJson<T> : ILeitorDeArquivos<T>
    {
        private string caminhoArquivo;

        public LeitorDeArquivoJson(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<T> RealizaLeitura()
        {
            using Stream stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<IEnumerable<T>>(stream, options) ?? Enumerable.Empty<T>();
        }
    }
}
