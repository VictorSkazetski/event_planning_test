using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Queries;
using event_planning_test_api.Domain.Queries.Handlers;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration
{
    public static class MediatRQueriesConfiguration
    {
        public static IServiceCollection AddMediatRQueries(
            this IServiceCollection services)
        {
            services.AddScoped<
                IRequestHandler<EventsQuery, List<EventsDto>>>(
                    sp => new EventsQueryHandler(
                        sp.GetRequiredService<ICrudBaseRepository<EventsEntity, int>>(),
                        sp.GetRequiredService<IMapper>(),
                        sp.GetRequiredService<ICrudBaseRepository<UserJoinEventsEntity, int>>()));

            return services;
        }
    }
}
