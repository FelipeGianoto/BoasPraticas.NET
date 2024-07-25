﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.UI
{
    internal static class ConsoleUI
    {
        public static void ExibeResultado(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                if (result.IsFailed)
                {
                    ExibeFalha(result);
                }
                else
                {
                    ExibeSucesso(result);
                }
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibeSucesso(Result result)
        {
            var sucesso = result.Successes.First();
            switch (sucesso)
            {
                case SuccessWithPets s:
                    ExibirPets(s);
                    break;
                case SuccessWithDocs d:
                    ExibeDocumentacao(d);
                    break;
                case SuccessWithClientes c:
                    ExibeClientes(c);
                    break;
            }
        }

        private static void ExibeClientes(SuccessWithClientes clientes)
        {
            foreach (var cliente in clientes.Data)
            {
                System.Console.WriteLine(cliente);
            }
            System.Console.WriteLine(clientes.Message);
        }

        private static void ExibeDocumentacao(SuccessWithDocs documentacaoComando)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets. \n");
            foreach (var doc in documentacaoComando.Documentacao)
            {
                System.Console.WriteLine(doc);
            }
        }

        private static void ExibirPets(SuccessWithPets pets)
        {
            foreach(var pet in pets.Data)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.WriteLine(pets.Message);
        }

        private static void ExibeFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            var error = result.Errors.First();
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}");
        }
    }
}
