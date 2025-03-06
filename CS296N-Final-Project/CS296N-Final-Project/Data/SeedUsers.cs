using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace CS296N_Final_Project.Data;

public class SeedUsers
{
    public static RoleManager<IdentityRole> roleManager;
    public static UserManager<AppUser> userManager;

    public static async Task CreateUsers(IServiceProvider provider)
    {
        roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
        userManager = provider.GetRequiredService<UserManager<AppUser>>();

        const string MEMBER = "Member";
        await CreateRole(MEMBER);
        const string ADMIN = "Admin";
        await CreateRole(ADMIN);

        const string SECRET_PASSWORD = "Secret!123";
        await CreateUser("admin", SECRET_PASSWORD, ADMIN);
        
        await CreateUser("Joseph", SECRET_PASSWORD, MEMBER);
        await CreateUser("Jynastie", SECRET_PASSWORD, MEMBER);
        await CreateUser("Kazner", SECRET_PASSWORD, MEMBER);

    }

    private static async Task CreateRole(string roleName)
    {
        if (await roleManager.FindByNameAsync(roleName) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    private static async Task CreateUser(string name, string password, string role)
    {
        var user = new AppUser
        {
            UserName = name,
            Name = name,
        };
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }

}