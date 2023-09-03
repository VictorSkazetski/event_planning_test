using event_planning_test_api.App.Routes;
using event_planning_test_api.Data.Dto;
using event_planning_test_api.Domain.Commands;
using event_planning_test_api.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace event_planning_test_api.Controllers;

[Authorize(Roles = "User")]
public class UserController : ControllerBase
{
    private readonly IMediator Mediator;

    public UserController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpGet(RouteParts.User)]
    public async Task<List<EventsDto>> GetEvents()
    {
        //var eventsData = await this.Mediator.Send(new EventsQuery());

        //return Ok(eventsData);

       return await this.Mediator.Send(new EventsQuery());
    }

    [HttpPost(RouteParts.User)]
    public async Task<List<EventsDto>> JoinEvent(
        [FromBody] int eventId)
    {
        //var eventsData = await this.Mediator.Send(new EventsQuery());

        //return Ok(eventsData);

         await this.Mediator.Send(
             new JoinUserEventCommand() 
            { 
                EventId = eventId
             });

        return null;
    }
}
