using event_planning_test_api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace event_planning_test_api.Infrastructure.Data.Configurations;

public class UserJoinEventsEntityConfiguration
    : IEntityTypeConfiguration<UserJoinEventsEntity>
{
    public void Configure(EntityTypeBuilder<UserJoinEventsEntity> builder)
    {
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.HasKey(e => new { e.UserId, e.EventId });
        builder.HasOne(u => u.User)
            .WithMany(e => e.UserJoinEvents)
            .HasForeignKey(u => u.UserId);
        builder.HasOne(e => e.Events)
            .WithMany(u => u.UserJoinEvents)
            .HasForeignKey(e => e.EventId);
    }
}
