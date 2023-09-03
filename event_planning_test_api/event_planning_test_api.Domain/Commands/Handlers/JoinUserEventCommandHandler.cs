using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Interfaces;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;

namespace event_planning_test_api.Domain.Commands.Handlers;

public class JoinUserEventCommandHandler :
        IRequestHandler<JoinUserEventCommand, JoinUserEventDto>
{
    private readonly ICrudBaseRepository<UserJoinEventsEntity, int> userJoinEventRepository;
    private readonly IMapper mapper;
    private readonly ICurrentUser currentUser;

    public JoinUserEventCommandHandler(
         ICrudBaseRepository<UserJoinEventsEntity, int> userJoinEventRepository,
         IMapper mapper,
         ICurrentUser currentUser)
    {
        this.userJoinEventRepository = userJoinEventRepository;
        this.mapper = mapper;
        this.currentUser = currentUser;
    }

    public async Task<JoinUserEventDto> Handle(
        JoinUserEventCommand request, 
        CancellationToken cancellationToken)
    {
        var joinEventData = await userJoinEventRepository.CreateAsync(
            new UserJoinEventsEntity()
            {
                UserId = (await currentUser.GetCurrentUser())
                    .Id,
                EventId = request.EventId
            });

        return mapper.Map<JoinUserEventDto>(joinEventData);
    }
}
