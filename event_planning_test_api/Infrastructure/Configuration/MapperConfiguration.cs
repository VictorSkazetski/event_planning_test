using event_planning_test_api.Data.Dto;
using event_planning_test_api.Data.Entities;
using Mapster;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class MapperConfiguration
{
    public static void ConfigureMapping(this TypeAdapterConfig config)
    {
        config
            .NewConfig<UserEntity, AccountDto>()
            .Map(x => x.UserEmail, x => x.Email);
    }
}
