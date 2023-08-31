using MimeKit;

namespace event_planning_test_api.Domain.Interfaces;

public interface IRegistrationEmail
{
    Task SendEmailAsync(MimeMessage email);
}
