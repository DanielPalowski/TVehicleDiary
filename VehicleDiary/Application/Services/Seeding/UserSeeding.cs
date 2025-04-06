using Microsoft.AspNetCore.Identity;
using VehicleDiary.Core.Constants;


namespace VehicleDiary.Application.Services.Seeding
{
    public class UserSeeding
    {
        public static async Task SeedingUsersAsync(IServiceProvider serviceProvider)
        {
            var userMananger = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            if (await userMananger.FindByEmailAsync(Users.Email) == null)
            {
                var user = new IdentityUser { UserName = Users.UserName, Email = Users.Email };
                await userMananger.CreateAsync(user, Users.Password);
                await userMananger.AddToRoleAsync(user, Roles.NormalUser);
            }

        }
    }
}
