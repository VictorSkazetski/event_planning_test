using event_planning_test_api.Data.Dto;
using MediatR;

namespace event_planning_test_api.Domain.Commands;

public class CreateUserAccountCommand : IRequest<AccountDto>
{
    public required string UserEmail { get; init; }

    public required string UserPassword { get; init; }
}
