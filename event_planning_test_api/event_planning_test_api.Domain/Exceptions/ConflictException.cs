namespace event_planning_test_api.Domain.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message)
        : base(message)
    {
    }
}

