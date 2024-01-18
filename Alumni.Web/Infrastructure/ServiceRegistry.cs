using Alumni.Web;
using Alumni.Web.Data;
using Alumni.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Web.Infrastructure
{
    public static class ServiceRegistry
    {
        public static void ApplyDatabaseMigrations(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (dbContext.Database.GetMigrations().Any())
            {
                dbContext.Database.Migrate();
            }
            if (!dbContext.Users.Any())
            {
                string adminEmail = "admin@gmail.com";

                var adminUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper()
                };
                var adminRole = new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                };
                var passwordHasher = new PasswordHasher<IdentityUser>();
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

                dbContext.Users.Add(adminUser);
                dbContext.Roles.AddRange(
                    new List<IdentityRole> {
                        adminRole,
                        new()
                        {
                            Id = "2",
                            Name = "Moderator",
                            NormalizedName = "Moderator".ToUpper()
                        },
                        new()
                        {
                            Id = "3",
                            Name = "Member",
                            NormalizedName = "Member".ToUpper()
                        }
                    });
                dbContext.UserRoles.Add(
                    new IdentityUserRole<string>
                    {
                        UserId = adminUser.Id,
                        RoleId = adminRole.Id
                    });

                dbContext.Profiles.Add(
                    new Models.Profile
                    {
                        UserId = adminUser.Id,
                        Email = adminEmail,
                    });

                dbContext.SaveChanges();
            }
        }
    }
}
