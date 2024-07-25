using Alura.Adopet.Console.Modelos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Utils
{
    public class SuccessWithClientes : Success
    {
        public SuccessWithClientes(IEnumerable<Cliente> data, string message) : base(message)
        {
            Data = data;
        }

        public IEnumerable<Cliente> Data { get; }
    }
}
