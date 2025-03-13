using Microsoft.AspNetCore.Identity;

namespace CS296N_Final_Project.Models;

public class UserVM
{
    public IEnumerable<AppUser> Users { get; set; } = null!;
    public IEnumerable<IdentityRole> Roles { get; set; } = null!;
}