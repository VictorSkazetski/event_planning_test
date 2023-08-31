using event_planning_test_api.Data.Options;
using event_planning_test_api.Domain.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace event_planning_test_api.Domain.Services;

public class RegistrationEmailService : IRegistrationEmail
{
    private readonly IOptions<MailClientOptions> mailOptions;

    public RegistrationEmailService(
        IOptions<MailClientOptions> mailOptions)
    {
        this.mailOptions = mailOptions;
    }

    public async Task SendEmailAsync(MimeMessage message)
    {
        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.mail.ru", 465, true);
        await client.AuthenticateAsync(
            mailOptions.Value
                .Email, 
            mailOptions.Value
                .Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
