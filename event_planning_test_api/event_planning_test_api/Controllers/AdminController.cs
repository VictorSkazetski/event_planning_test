using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using event_planning_test_api.App.Routes;
using event_planning_test_api.Data.Dto;
using event_planning_test_api.Domain.Commands;

namespace event_planning_test_api.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IMediator Mediator;

    public AdminController(IMediator mediator)
    {
        this.Mediator = mediator;
    }

    [HttpPost(RouteParts.Admin)]
    public async Task<EventDto> CreateEvent([FromBody] dynamic eventData)
    {
        return await Mediator.Send(
            new CreateEventCommand()
            { 
                JsonEvent = eventData.ToString()
            });
    }
}
