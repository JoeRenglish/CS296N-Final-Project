using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CS296N_Final_Project.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Character> Characters { get; set; }
    public DbSet<Armor> Armor { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Consumable> Consumables { get; set; }
    public DbSet<Class> Classes { get; set; }
}