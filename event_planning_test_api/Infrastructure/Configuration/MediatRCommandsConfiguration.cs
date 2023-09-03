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
        services.AddScoped<
                IRequestHandler<VerifyUserAccountEmailCommand, UserEmailVerifyDto>>(
                    sp => new VerifyUserAccountEmailCommandHandler(
                        sp.GetRequiredService<UserManager<UserEntity>>(),
                        sp.GetRequiredService<IMapper>()));
        services.AddScoped<
                IRequestHandler<LoginUserAccountCommand, UserTokenDto>>(
                    sp => new LoginUserAccountCommandHandler(
                        sp.GetRequiredService<UserManager<UserEntity>>(),
                        sp.GetRequiredService<IMapper>(),
                        sp.GetRequiredService<IJWTManager>()));
        services.AddScoped<
                IRequestHandler<CreateEventCommand, EventDto>>(
                    sp => new CreateEventCommandHandler(
                        sp.GetRequiredService<ICrudBaseRepository<EventsEntity, int>>(),
                        sp.GetRequiredService<IMapper>()));
        services.AddScoped<
                IRequestHandler<JoinUserEventCommand, JoinUserEventDto>>(
                    sp => new JoinUserEventCommandHandler(
                        sp.GetRequiredService<ICrudBaseRepository<UserJoinEventsEntity, int>>(),
                        sp.GetRequiredService<IMapper>(),
                        sp.GetRequiredService<ICurrentUser>()));

        return services;
    }
}
