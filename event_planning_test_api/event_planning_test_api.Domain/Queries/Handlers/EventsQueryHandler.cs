using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;

namespace event_planning_test_api.Domain.Queries.Handlers;

public class EventsQueryHandler :
    IRequestHandler<EventsQuery, List<EventsDto>>
{
    private readonly ICrudBaseRepository<EventsEntity, int> eventsRepository;
    private readonly IMapper mapper;
    private readonly ICrudBaseRepository<UserJoinEventsEntity, int> userJoinEventRepository;

    public EventsQueryHandler(
        ICrudBaseRepository<EventsEntity, int> eventsRepository,
        IMapper mapper,
        ICrudBaseRepository<UserJoinEventsEntity, int> userJoinEventRepository)
    {
        this.eventsRepository = eventsRepository;
        this.mapper = mapper;
        this.userJoinEventRepository = userJoinEventRepository;

    }

    public async Task<List<EventsDto>> Handle(
        EventsQuery request,
        CancellationToken cancellationToken)
    {
        var eventsDataMap = new List<EventsDto>();
        var eventsDataMapDone = new List<EventsDto>();
        var eventsData = await eventsRepository.GetAllAsync();
        var userJoinEventsDictionary = (await userJoinEventRepository.GetAllAsync())
            .GroupBy(e => e.EventId)
            .ToDictionary(i => i.Key, i => i.Count());
        var eventsCountDictionary = eventsData.Select(e =>
            new
            {
                e.Id,
                e.UserCount,
            })
            .ToDictionary(e => e.Id, e => e.UserCount);
        var concatDictionary = 
            userJoinEventsDictionary.Concat(
                eventsCountDictionary.Where(kvp => !userJoinEventsDictionary.ContainsKey(kvp.Key)))
                    .ToDictionary(i => i.Key, i => i.Value);
        var checkUserCountDictionary = 
            eventsCountDictionary.ToDictionary(p => p.Key, p => p.Value - concatDictionary[p.Key]);
        foreach (var item in checkUserCountDictionary)
        {
            if (!userJoinEventsDictionary.ContainsKey(item.Key))
            {
                checkUserCountDictionary[item.Key] = -1;
            }
        }

        foreach (var eventItem in eventsData)
        {
            eventsDataMap.Add(mapper.Map<EventsDto>(
                checkUserCountDictionary.First(x => x.Key == eventItem.Id)));
        }

        foreach (var eventItem in eventsData)
        {
            eventsDataMapDone.Add(mapper.Map<EventsDto>(eventItem));
        }

        return eventsDataMap;
    }
}
