using donet_test_by_carro.Interfaces;
using donet_test_by_carro.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace donet_test_by_carro.Services
{
    public class EmailService : IEmail
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService(IConfiguration config , IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }
        public void SendEmail(EmailRequest request)
        {
            var user = (User?)_httpContextAccessor.HttpContext!.Items["User"];
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(user.Email));
            email.To.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
