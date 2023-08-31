using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Data.Types;
using event_planning_test_api.Domain.Exceptions;
using event_planning_test_api.Domain.Interfaces;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace event_planning_test_api.Domain.Commands.Handlers;

public class CreateUserAccountCommandHandler :
    IRequestHandler<CreateUserAccountCommand, AccountDto>
{
    private readonly UserManager<UserEntity> userManager;
    private readonly IMapper mapper;
    private readonly IRegistrationEmail emailService;
    private readonly IRegistrationEmailMessage registrationMessageService;
    private readonly ICrudBaseRepository<IdentityUserRole<int>, int> crudBaseRepository;

    public CreateUserAccountCommandHandler(
        UserManager<UserEntity> userManager,
        IMapper mapper,
        IRegistrationEmail emailService,
        IRegistrationEmailMessage registrationMessageService,
        ICrudBaseRepository<IdentityUserRole<int>, int> crudBaseRepository)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.emailService = emailService;
        this.registrationMessageService = registrationMessageService;
        this.crudBaseRepository = crudBaseRepository;
    }

    public async Task<AccountDto> Handle(
        CreateUserAccountCommand request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail);
        if (user != default)
        {
            throw new ConflictException("Пользователь уже существует");
        }

        await userManager.CreateAsync(
            new UserEntity
            {
                UserName = request.UserEmail,
                Email = request.UserEmail,
            },
            request.UserPassword);
        var userCreated = await userManager.FindByEmailAsync(
            request.UserEmail);
        await crudBaseRepository.CreateAsync(
            new IdentityUserRole<int>
            {
                RoleId = RolesType.UserRoleId,
                UserId = userCreated.Id

            });
        var token = await userManager.GenerateEmailConfirmationTokenAsync(
            userCreated);
        var message = registrationMessageService.GetMessage(
            request.UserEmail, token);
        await emailService.SendEmailAsync(message);

        return mapper.Map<AccountDto>(userCreated);
    }
}
