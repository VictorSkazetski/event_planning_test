namespace event_planning_test_api.Data.Entities;

public class UserJoinEventsEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public UserEntity User { get; set; }

    public int EventId { get; set; }

    public EventsEntity Events { get; set; }
}
