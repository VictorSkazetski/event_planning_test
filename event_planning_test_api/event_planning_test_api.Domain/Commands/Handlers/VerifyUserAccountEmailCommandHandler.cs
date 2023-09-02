
using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Exceptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace event_planning_test_api.Domain.Commands.Handlers;

public class VerifyUserAccountEmailCommandHandler :
    IRequestHandler<VerifyUserAccountEmailCommand, UserEmailVerifyDto>
{
    private readonly UserManager<UserEntity> userManager;
    private readonly IMapper mapper;

    public VerifyUserAccountEmailCommandHandler(
        UserManager<UserEntity> userManager,
        IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<UserEmailVerifyDto> Handle(
            VerifyUserAccountEmailCommand request,
            CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail);
        var isEmailVerified = await userManager.ConfirmEmailAsync(user, request.Token);
        if (isEmailVerified.Succeeded)
        {
            return this.mapper.Map<UserEmailVerifyDto>(user);
        }
        else
        {
            throw new VerifyUserEmailException("Что-то пошло не так");
        }
    }
}
