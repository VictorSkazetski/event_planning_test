using event_planning_test_api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace event_planning_test_api.Infrastructure.Data.Configurations;

public class EventsEntityConfiguration : IEntityTypeConfiguration<EventsEntity>
{
    public void Configure(EntityTypeBuilder<EventsEntity> builder)
    {
        builder.Property(p => p.Id)
            .UseIdentityColumn();
        builder.Property(p => p.JsonEvent)
            .HasColumnType("VARCHAR(MAX)");
        builder.Property(p => p.UserCount)
            .IsRequired();
    }
}
