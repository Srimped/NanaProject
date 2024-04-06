using System.Globalization;
using Microsoft.AspNetCore.Identity;

namespace NanaProject.Models;

public static class NanaDbExtensions
{
    public static async Task SeedData(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            
            var roles = new[] {"Admin", "Staff", "Member"};

            var emails = new[] {"admin@gmail.com", "staff@gmail.com", "member@gmail.com"};
            string password = "Test@123"; 

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            
            }

            foreach (var email in emails)
            {
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new IdentityUser();
                    user.UserName = email;
                    user.Email = email;

                    await userManager.CreateAsync(user, password);

                    if (email == "admin@gmail.com")
                        await userManager.AddToRoleAsync(user, "Admin");
                    else if (email == "staff@gmail.com")
                        await userManager.AddToRoleAsync(user, "Staff");
                    else
                        await userManager.AddToRoleAsync(user, "Member");
                }
            }
        }
    }
}