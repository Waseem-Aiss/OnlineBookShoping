using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Constants;
using System.Data;

namespace OnlineBookShoping.Data
{
    public class DbSeeder
    {
        public static async Task AddDefaulData(IServiceProvider service)
        {


            var context = service.GetService<ApplicationDbContext>();

            if ((await context.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await context.Database.MigrateAsync();

            }
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();

            var adminRoleExists = await roleMgr.RoleExistsAsync(Roles.Admin.ToString());
            if (!adminRoleExists)
            {
                await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            }
            var userRoleExists = await roleMgr.RoleExistsAsync(Roles.User.ToString());
            if (!userRoleExists)
            {
                await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }

            var admin = new IdentityUser
            {
                UserName = "admin",
                Email = "waseemaiss784@gmail.com",
                EmailConfirmed = true
            };
            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if(userInDb is null)
            {
                await userMgr.CreateAsync(admin, "Waseem@784");
            await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());
            }

            if (!context.Genres.Any())
            {
             
            }



        }
    }
}