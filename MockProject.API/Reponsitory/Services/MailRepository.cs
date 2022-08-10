using MockProject.API.Reponsitory.Interface;
using System.Net;
using System.Net.Mail;

namespace MockProject.API.Reponsitory.Services
{
    public class MailRepository : IMailRepository
    {
        private IConfiguration _configuration;
        public MailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMail(string toEmail, string subject, string content)
        {
            string sendEmail = _configuration["SendMailConfig:Username"];
            string password = _configuration["SendMailConfig:Password"];
            string smtpAddress = "smtp.gmail.com";
            int port = 587;
            // Create new mail
            using MailMessage mail = new MailMessage();
            // Setup mail information
            mail.From = new MailAddress(sendEmail);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = content;
            mail.IsBodyHtml = true;
            // Create SMTP client to send mail
            using SmtpClient smtp = new SmtpClient(smtpAddress, port);
            smtp.Credentials = new NetworkCredential(sendEmail, password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }
    }
}
