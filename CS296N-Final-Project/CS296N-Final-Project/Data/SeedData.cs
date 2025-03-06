using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity;


namespace CS296N_Final_Project.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        if (!context.Characters.Any())
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            
            var joseph = userManager.FindByNameAsync("Joseph").Result;
            var jynastie = userManager.FindByNameAsync("Jynastie").Result;
            var kazner = userManager.FindByNameAsync("Kazner").Result;

            var stats = new Stats
            {
                Attack = 1,
                Defense = 1,
                HitPoints = 10,
                Speed = 1
            };

            var characterClass = new Class
            {
                Name = "Warrior",
                Description = "A melee fighter."
            };

            var weapon = new Weapon
            {
                Name = "Short Sword",
                Description = "A short sword.",
                Damage = 2,
                Element = ""
            };

            var armor = new Armor
            {
                Name = "Leather Armor",
                Description = "A set of leather armor.",
                DamageReduction = 2
            };

            var accessory = new Accessory
            {
                Name = "Silver Bracelet",
                Description = "A beautiful, silver bracelet.",
                Effect = ""
            };

            var consumable = new Consumable
            {
                Name = "Potion",
                Description = "A vial of healing potion.",
                Effect = "",
                HealValue = 3
            };

            var equipment = new Equipment
            {
                Weapon = weapon,
                Armor = armor,
                Accessory = accessory,
                Consumable = consumable,
            };

            var character = new Character
            {
                AppUser = joseph,
                Name = "Hawk",
                Stats = stats,
                Class = characterClass,
                Equipment = equipment
            };
        }
    }
}