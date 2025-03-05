using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CS296N_Final_Project.Models;

public class AppUser : IdentityUser
{
    public DateTime SignUpDate { get; set; }
    public string? Name { get; set; }
    
    [NotMapped] 
    public IList<string> RoleNames { get; set; } = null!;
}