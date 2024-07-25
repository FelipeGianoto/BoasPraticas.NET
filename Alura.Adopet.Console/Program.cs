using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Utils;
using FluentResults;

IComando? comando = ComandosFacotry.CriarComando(args);
if (comando is not null)
{
    var resultado = await comando.ExecutarAsync();
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando inválido!"));
}
