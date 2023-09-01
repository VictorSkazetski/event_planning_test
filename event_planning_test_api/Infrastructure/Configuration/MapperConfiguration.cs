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
            .Map(x => x.UserEmail, x => x.NormalizedEmail)
            .Map(x => x.EmailHost, x => "https://" +
                    x.NormalizedEmail.Split('@', StringSplitOptions.None)[1]);
        config
            .NewConfig<UserEntity, UserEmailVerifyDto>()
            .Map(x => x.UserEmail, x => x.Email);
    }
}
