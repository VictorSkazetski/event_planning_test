using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;
using Newtonsoft.Json.Linq;

namespace event_planning_test_api.Domain.Commands.Handlers;

public class CreateEventCommandHandler :
    IRequestHandler<CreateEventCommand, EventDto>
{
    private readonly ICrudBaseRepository<EventsEntity, int> eventsRepository;
    private readonly IMapper mapper;

    public CreateEventCommandHandler(
        ICrudBaseRepository<EventsEntity, int> eventsRepository,
        IMapper mapper)
    {
        this.eventsRepository = eventsRepository;
        this.mapper = mapper;
    }

    public async Task<EventDto> Handle(
        CreateEventCommand request, 
        CancellationToken cancellationToken)
    {
        dynamic eventsData = JObject.Parse(request.JsonEvent);
        var eventCreated = await eventsRepository.CreateAsync(
            new EventsEntity
            {
                JsonEvent = request.JsonEvent,
                UserCount = (int)eventsData.userCount
            });

        return mapper.Map<EventDto>(eventCreated);
    }
}
