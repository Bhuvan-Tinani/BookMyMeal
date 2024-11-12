using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookMyMeal.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = "ceb5f5e0-9eb9-4600-907a-7aa0dc88a44b";
            var empRoleId = "a5d42791-064e-4998-9962-5d44b740c8fb";
            //Create reader and writer role
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name="admin",
                    NormalizedName="admin".ToUpper(),
                    ConcurrencyStamp=adminRoleId
                },
                new IdentityRole()
                {
                    Id = empRoleId,
                    Name="employee",
                    NormalizedName="employee".ToUpper(),
                    ConcurrencyStamp=empRoleId
                }
            };
            //seed the role
            builder.Entity<IdentityRole>().HasData(roles);

            //create admin user
            var adminUserId = "3e0892bb-02e5-4beb-bfba-25c2ba56c69d";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@bookmeal.com",
                Email = "admin@bookmeal.com",
                NormalizedEmail = "admin@bookmeal.com".ToUpper(),
                NormalizedUserName = "admin@bookmeal.com".ToUpper()
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "admin@123");
            builder.Entity<IdentityUser>().HasData(admin);
            //give role to admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId= adminUserId,
                    RoleId=adminRoleId
                },
                new()
                {
                    UserId= adminUserId,
                    RoleId=empRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}
