using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(string remetente, string destinatario, string titulo, string corpo);
    }
}
