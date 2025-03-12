using System.ComponentModel.DataAnnotations;

namespace CS296N_Final_Project.Models;

public class LoginVM
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string Password { get; set; } = string.Empty;
    
    public string ReturnUrl { get; set; } = string.Empty;
    public bool RememberMe { get; set; } 
}