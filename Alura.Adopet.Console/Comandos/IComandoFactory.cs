namespace Alura.Adopet.Console.Comandos
{
    public interface IComandoFactory
    {
        IComando? CriarComando(string[] argumentos);
        bool ConsegueCriarOTipo(Type? tipoComando);
    }
}
