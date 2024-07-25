using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class PetsDoJson : LeitorDeArquivoJson<Pet>
    {
        public PetsDoJson(string caminhoArquivo) : base(caminhoArquivo)
        {
        }
    }
}
