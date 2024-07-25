using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
        documentacao: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly ILeitorDeArquivos<Pet> leitor;

        public Show(ILeitorDeArquivos<Pet> leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return this.ExibeConteudoArquivo();
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Importação falhou!").CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {
            IEnumerable<Pet> listaDepets = leitor.RealizaLeitura();
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));

        }
    }
}
