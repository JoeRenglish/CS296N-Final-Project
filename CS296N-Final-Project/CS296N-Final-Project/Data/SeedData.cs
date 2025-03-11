using CS296N_Final_Project.Models;
using Microsoft.AspNetCore.Identity;


namespace CS296N_Final_Project.Data;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        if (!context.Characters.Any())
        {
            // Get the user manager
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            
            // Get the pre-created users that were made in SeedUsers
            var joseph = userManager.FindByNameAsync("Joseph").Result;
            var jynastie = userManager.FindByNameAsync("Jynastie").Result;
            var kazner = userManager.FindByNameAsync("Kazner").Result;
            
            // Create a new Class
            var characterClass = new Class
            {
                Name = "Warrior",
                Description = "A melee fighter."
            };
            
            // Add the created class to the context
            context.Classes.Add(characterClass);
            
            // Create a new Weapon
            var weapon = new Weapon
            {
                Name = "Short Sword",
                Description = "A short sword.",
                Damage = 2,
                Element = ""
            };
            
            // Add the created weapon to the context
            context.Weapons.Add(weapon);
            
            // Create a new piece of armor
            var armor = new Armor
            {
                Name = "Leather Armor",
                Description = "A set of leather armor.",
                DamageReduction = 2
            };
            
            // Add the created armor to the context
            context.Armor.Add(armor);
            
            // Create a new accessory 
            var accessory = new Accessory
            {
                Name = "Silver Bracelet",
                Description = "A beautiful, silver bracelet.",
                Effect = ""
            };
            
            // Add the created accessory to the context
            context.Accessories.Add(accessory);
            
            // Create a new consumable
            var consumable = new Consumable
            {
                Name = "Potion",
                Description = "A vial of healing potion.",
                Effect = "",
                HealValue = 3
            };
            
            // Add the created consumable to the context
            context.Consumables.Add(consumable);

            // Create a new character
            var character = new Character
            {
                AppUser = joseph,
                Name = "Hawk",
                Stats = new Stats
                {
                    Attack = 1,
                    Defense = 1,
                    HitPoints = 10,
                    Speed = 1
                },
                Class = characterClass,
                Equipment = new Equipment
                {
                    Weapon = weapon,
                    Armor = armor,
                    Accessory = accessory,
                    Consumable = consumable,
                }
            };
            
            // Add the created character to the context
            context.Characters.Add(character);
            
            character = new Character
            {
                AppUser = jynastie,
                Name = "Alice",
                Stats = new Stats
                {
                    Attack = 1,
                    Defense = 1,
                    HitPoints = 10,
                    Speed = 1
                },
                Class = characterClass,
                Equipment = new Equipment
                {
                    Weapon = weapon,
                    Armor = armor,
                    Accessory = accessory,
                    Consumable = consumable,
                }
            };
            
            context.Characters.Add(character);
            
            character = new Character
            {
                AppUser = kazner,
                Name = "Grugg",
                Stats = new Stats
                {
                    Attack = 1,
                    Defense = 1,
                    HitPoints = 10,
                    Speed = 1
                },
                Class = characterClass,
                Equipment = new Equipment
                {
                    Weapon = weapon,
                    Armor = armor,
                    Accessory = accessory,
                    Consumable = consumable,
                }
            };

            context.Characters.Add(character);
            // Store all the items added to the context
            context.SaveChanges();

        }
    }
}