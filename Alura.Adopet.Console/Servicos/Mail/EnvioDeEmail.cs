using Alura.Adopet.Console.Settings;
using Alura.Adopet.Console.Utils;
using FluentResults;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public static class EnvioDeEmail
    {
        private static IMailService CriarMailService()
        {
            MailSettings settings = Configurations.MailSetting;

            SmtpClient smtp = new()
            {
                Host = settings.Servidor,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
            return new SmtpClientMailService(smtp);
        }

        public static void Disparar(Result resultado)
        {
            ISuccess? success = resultado.Successes.FirstOrDefault();
            if (success is null) return;

            if(success is SuccessWithPets sucesso)
            {
                var emailService = CriarMailService();
                emailService.SendMailAsync(
                    remetente: "no-reply@adopet.com.br",
                    titulo: $"[Adopet] {sucesso.Message}",
                    corpo: $"Foram importados {sucesso.Data.Count()} pets",
                    destinatario: "felipe.gianoto1234@gmail.com"
                );
            }
        }
    }
}
