using event_planning_test_api.Data.Entities;
using event_planning_test_api.Data.Options;
using event_planning_test_api.Data.Types;
using event_planning_test_api.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace event_planning_test_api.Infrastructure.Data;

public class DbContext : IdentityDbContext<UserEntity, RolesEnity, int>
{
    private readonly IOptions<AdminSeedOptions> adminOptions;

    public DbContext(DbContextOptions<DbContext> options,
        IOptions<AdminSeedOptions> adminOptions)
        : base(options)
    {
        this.adminOptions = adminOptions;
    }

    public virtual DbSet<EventsEntity> Events { get; set; }

    public virtual DbSet<UserJoinEventsEntity> UserJoinEvents { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserJoinEventsEntityConfiguration());
        base.OnModelCreating(modelBuilder);
        var passwordHash = new PasswordHasher<UserEntity>();
        modelBuilder.Entity<UserEntity>()
            .HasData(
                new UserEntity
                {
                    Id = 1,
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = passwordHash.HashPassword(
                        null, 
                        adminOptions.Value
                            .Password),
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
        );
        modelBuilder.Entity<RolesEnity>()
            .HasData(
                new RolesEnity
                {
                    Id = 1,
                    Name = RolesType.User
                },
                new RolesEnity
                {
                    Id = 2,
                    Name = RolesType.Admin
                }
        );
        modelBuilder.Entity<IdentityUserRole<int>>()
            .HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 2,
                    UserId = 1
                }
        );
    }
}
