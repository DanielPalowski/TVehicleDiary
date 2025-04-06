using Microsoft.AspNetCore.Identity;
using VehicleDiary.Core.Constants;

namespace VehicleDiary.Application.Services.Seeding
{
    public class RoleSeeding
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.NormalUser))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.NormalUser));
            }
        }
    }
}
