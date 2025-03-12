using System.ComponentModel.DataAnnotations;

namespace CS296N_Final_Project.Models;

public class RegisterVM
{
    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please confirm your password")]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword")]
    public string ConfirmPassword { get; set; } = string.Empty;
}