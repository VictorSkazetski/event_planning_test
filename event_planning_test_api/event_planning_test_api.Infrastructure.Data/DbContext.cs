using event_planning_test_api.Data.Entities;
using event_planning_test_api.Data.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace event_planning_test_api.Infrastructure.Data;

public class DbContext : IdentityDbContext<UserEntity, RolesEnity, int>
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                    PasswordHash = passwordHash.HashPassword(null, "123123qweQWE!"),
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
