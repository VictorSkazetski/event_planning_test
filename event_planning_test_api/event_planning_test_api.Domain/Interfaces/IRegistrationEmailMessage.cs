using MimeKit;

namespace event_planning_test_api.Domain.Interfaces;

public interface IRegistrationEmailMessage
{
    MimeMessage GetMessage(string userEmail, string token);
}
