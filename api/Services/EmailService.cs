using System.Net;
using System.Net.Mail;
using api.Interfaces;

namespace api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpHost = _configuration["Email:SmtpHost"];
                var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);
                var smtpUser = _configuration["Email:Username"];
                var smtpPass = _configuration["Email:Password"];

                using var client = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(smtpUser, smtpPass),
                    EnableSsl = true
                };

                var mail = new MailMessage(smtpUser, toEmail, subject, body);
                await client.SendMailAsync(mail);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }

        }
    }
}