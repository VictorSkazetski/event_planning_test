namespace event_planning_test_api.Data.Options;

public class JwtOptions
{
    public required string Key { get; init; }

    public required string Issuer { get; init; }

    public required string Audience { get; init; }
}
