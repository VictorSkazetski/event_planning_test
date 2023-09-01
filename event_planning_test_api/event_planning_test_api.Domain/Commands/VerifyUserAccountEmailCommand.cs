using event_planning_test_api.Data.Dto;
using MediatR;

namespace event_planning_test_api.Domain.Commands;

public class VerifyUserAccountEmailCommand : IRequest<UserEmailVerifyDto>
{
    public required string UserEmail { get; init; }

    public required string Token { get; init; }
}
