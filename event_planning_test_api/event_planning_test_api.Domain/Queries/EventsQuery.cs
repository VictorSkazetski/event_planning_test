using event_planning_test_api.Data.Dto;
using MediatR;

namespace event_planning_test_api.Domain.Queries;

public class EventsQuery : IRequest<List<EventsDto>>
{
}
