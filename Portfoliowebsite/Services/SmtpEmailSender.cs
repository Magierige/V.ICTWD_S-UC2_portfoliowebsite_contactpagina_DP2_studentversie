using System.Net;
using System.Net.Mail;

namespace Portfoliowebsite.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        public SmtpEmailSender(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendAsync(string Name, string Email, string Subject, string Message)
        {
            var smtp = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]))
            {
                EnableSsl = false,
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]) // TODO: vervang met je eigen mailtrap credentials
            };

            var mail = new MailMessage();
            mail.From = new MailAddress("noreply@example.com", "Website");

            mail.To.Add("contact@example.com");

            mail.Subject = $"Contact: {Subject}";
            mail.Body = $"Naam: {Name}\nEmail: {Email}\nBericht:\n{Message}";

            await smtp.SendMailAsync(mail);
        }
    }
}
