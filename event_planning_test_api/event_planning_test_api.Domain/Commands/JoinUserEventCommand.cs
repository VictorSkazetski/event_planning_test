
using event_planning_test_api.Data.Dto;
using MediatR;

namespace event_planning_test_api.Domain.Commands;

public class JoinUserEventCommand : IRequest<JoinUserEventDto>
{
    public required int EventId { get; init; }
}
