using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        //seed data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "54906b20-f32c-4317-8cb3-24be5e03b969";
            var writerRoleId = "6b825762-01ac-4fc8-a9c8-67d6245e4d08";

            //create two roles, reader and writer
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId,
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId,
                }
            };

            //seed the roles in the database
            builder.Entity<IdentityRole>().HasData(roles);

            //create admin user
            var adminUserId = "db99c764-92e6-4a72-b7d5-330652da937d";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@blogsite.com",
                NormalizedUserName = "admin@blogsite.com".ToUpper(),
                Email = "admin@blogsite.com",
                NormalizedEmail = "admin@blogsite.com".ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            //seed admin in database
            builder.Entity<IdentityUser>().HasData(admin);

            //give roles to admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId,
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId,
                }
            };

            //seed admin roles in database
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
