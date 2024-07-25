using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoText(this string? linha)
        {
            if (linha is null) throw new ArgumentNullException("O Texto nao pode ser nulo!");
            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("O Texto nao pode ser vazio!");

            string[]? propriedades = linha.Split(';');

            if (propriedades.Length != 3) throw new ArgumentException("O Texto inválido!");

            bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);
            if (!sucesso) throw new ArgumentException("Guid inválido!");

            sucesso = int.TryParse(propriedades[2], out int tipoPet);
            if (!sucesso) throw new ArgumentException("Tipo de Pet inválido!");
            if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException("Tipo de Pet inválido!");

            Pet pet = new Pet(petId,  
            propriedades[1],
            tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
            );

            return pet;
        }
    }
}
