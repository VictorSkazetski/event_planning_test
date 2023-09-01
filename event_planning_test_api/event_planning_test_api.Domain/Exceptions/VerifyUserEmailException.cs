namespace event_planning_test_api.Domain.Exceptions
{
    public class VerifyUserEmailException : Exception
    {
        public VerifyUserEmailException(string message)
            : base(message)
        {
        }
    }
}
