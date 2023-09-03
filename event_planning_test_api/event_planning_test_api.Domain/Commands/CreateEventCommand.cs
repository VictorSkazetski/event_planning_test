using event_planning_test_api.Data.Dto;
using MediatR;

namespace event_planning_test_api.Domain.Commands;

public class CreateEventCommand : IRequest<EventDto>
{
    public required string JsonEvent { get; init; }
}
