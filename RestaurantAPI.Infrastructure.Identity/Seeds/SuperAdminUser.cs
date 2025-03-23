using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Infrastructure.Identity.Entities;

namespace RestaurantAPI.Infrastructure.Identity.Seeds
{
    public static class SuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser adminUser = new();
            adminUser.UserName = "superAdmin";
            adminUser.Email = "superadmin@localhost.com";
            adminUser.FirstName = "Super";
            adminUser.LastName = "Admin";
            adminUser.EmailConfirmed = true;
            adminUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(adminUser, "Us3r*D3f41t3");
                    await userManager.AddToRoleAsync(adminUser, Roles.Waiter.ToString());
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                }
            }
        }
    }
}
