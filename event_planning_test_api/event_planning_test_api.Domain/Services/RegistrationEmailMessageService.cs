using System.Text;
using event_planning_test_api.Data.Options;
using event_planning_test_api.Domain.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Options;
using MimeKit;

namespace event_planning_test_api.Domain.Services
{
    public class RegistrationEmailMessageService : IRegistrationEmailMessage
    {
        private readonly IOptions<MailClientOptions> mailOptions;

        public RegistrationEmailMessageService(
            IOptions<MailClientOptions> mailOptions)
        {
            this.mailOptions = mailOptions;                      
        }

        public MimeMessage GetMessage(string userEmail, string token)
        {
            var confirmationlink =
                    "https://localhost:4200/account/verify?token=" +
                    Convert.ToBase64String(
                        Encoding.UTF8.GetBytes(token)) +
                    "&email=" +
                    Convert.ToBase64String(
                        Encoding.UTF8.GetBytes(userEmail));
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(
                new MailboxAddress("Администрация сайта", mailOptions.Value.Email));
            emailMessage.To.Add(new MailboxAddress("", userEmail));
            emailMessage.Subject = "Завершение регистрации";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = 
                    $"<h1>Привет! перейдите по ссылке чтобы подтвердить email!</h1>" +
                    $"<a href='{confirmationlink}'>Ссылка</a>",
            };

            return emailMessage;
        }
    }
}
