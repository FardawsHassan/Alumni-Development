using System.Net.Mail;
using System.Net;

namespace Alumni.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("shuvropust18@gmail.com", "rrpddoyjdcznbhwq")
            };

            MailMessage mail = new MailMessage(from: "shuvropust18@gmail.com",to: email,subject,message);
            mail.IsBodyHtml = true;
            return client.SendMailAsync(mail);
        }
    }
}
