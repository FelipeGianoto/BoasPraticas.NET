using Alura.Adopet.Console.Utils;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
       documentacao: "adopet help comando que exibe informações de ajuda.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComando> docs;
        private string? comando;

        public Help(string? comando)
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
            this.comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return Task.FromResult(Result.Ok()
                  .WithSuccess(new SuccessWithDocs(this.GerarDocumentacao())));
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception)));
            }
        }

        private IEnumerable<string> GerarDocumentacao()
        {
            List<string> resultado = new List<string>();
            if (this.comando is null)
            {
                foreach (var doc in docs.Values)
                {
                    resultado.Add(doc.Documentacao);
                }
            }
            else
            {
                if (docs.ContainsKey(this.comando))
                {
                    var comando = docs[this.comando];
                    resultado.Add(comando.Documentacao);
                }
                else
                {
                    resultado.Add("Comando não encontrado!");
                    throw new ArgumentException();
                }
            }
            return resultado;
        }
    }
}
