using System.Net;
using System.Net.Mail;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            string gmail = IEmailConst.Gmail;
            string pass = IEmailConst.Pass;

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(gmail, pass)
            };

            return client.SendMailAsync(new MailMessage(from: gmail, to: email, subject, message));

        }
    }
}
