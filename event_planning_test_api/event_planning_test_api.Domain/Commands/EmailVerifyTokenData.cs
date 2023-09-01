namespace event_planning_test_api.Domain.Commands;

public class EmailVerifyTokenData
{
    public string UserEmail { get; set; }
    public string Token { get; set; }
}
