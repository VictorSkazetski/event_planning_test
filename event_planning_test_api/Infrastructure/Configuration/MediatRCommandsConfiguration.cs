using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Commands;
using event_planning_test_api.Domain.Commands.Handlers;
using event_planning_test_api.Domain.Interfaces;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class MediatRCommandsConfiguration
{
    public static IServiceCollection AddMediatRCommands(
        this IServiceCollection services)
    {
        services.AddScoped<
            IRequestHandler<CreateUserAccountCommand, AccountDto>>(
                sp => new CreateUserAccountCommandHandler(
                    sp.GetRequiredService<UserManager<UserEntity>>(),
                    sp.GetRequiredService<IMapper>(),
                    sp.GetRequiredService<IRegistrationEmail>(),
                    sp.GetRequiredService<IRegistrationEmailMessage>(),
                    sp.GetRequiredService<ICrudBaseRepository<IdentityUserRole<int>, int>>()));

        return services;
    }
}
