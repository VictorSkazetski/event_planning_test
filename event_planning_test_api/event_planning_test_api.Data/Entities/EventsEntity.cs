namespace event_planning_test_api.Data.Entities;

public class EventsEntity
{
    public int Id { get; set; }

    public string JsonEvent { get; set; }

    public int UserCount { get; set; }

    public List<UserJoinEventsEntity> UserJoinEvents { get; set; }
}
