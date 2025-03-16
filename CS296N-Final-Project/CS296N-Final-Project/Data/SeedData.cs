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
            var weapon = new Item
            {
                Name = "Short Sword",
                Description = "A short sword.",
                AttackValue = 2,
                DefenseValue = 0,
                SpeedValue = 0,
                HealValue = 0,
                Category = "Weapon",
            };
            
            // Add the created weapon to the context
            context.Items.Add(weapon);
            
            // Create a new piece of armor
            var armor = new Item
            {
                Name = "Leather Armor",
                Description = "A set of leather armor.",
                AttackValue = 0,
                DefenseValue = 2,
                SpeedValue = 0,
                HealValue = 0,
                Category = "Armor",
            };
            
            // Add the created armor to the context
            context.Items.Add(armor);
            
            // Create a new accessory 
            var accessory = new Item
            {
                Name = "Silver Bracelet",
                Description = "A beautiful, silver bracelet.",
                AttackValue = 0,
                DefenseValue = 0,
                SpeedValue = 1,
                HealValue = 0,
                Category = "Accessory",
            };
            
            // Add the created accessory to the context
            context.Items.Add(accessory);
            
            // Create a new consumable
            var consumable = new Item
            {
                Name = "Potion",
                Description = "A vial of healing potion",
                AttackValue = 0,
                DefenseValue = 0,
                SpeedValue = 0,
                HealValue = 3,
                Category = "Consumable",
            };
            
            // Add the created consumable to the context
            context.Items.Add(consumable);

            // Create a new character
            var character = new Character
            {
                AppUser = joseph,
                Name = "Hawk",
                Class = characterClass,
                Strength = 1,
                Vigor = 1,
                Dexterity = 1,
                HitPoints = 10,
                MagicPoints = 10,
                Level = 1,
                Experience = 0,
                Weapon = weapon,
                Armor = armor,
                Accessory = accessory,
            };
            
            // Add the created character to the context
            context.Characters.Add(character);
            
            character = new Character
            {
                AppUser = jynastie,
                Name = "Alice",
                Class = characterClass,
                Strength = 1,
                Vigor = 1,
                Dexterity = 1,
                HitPoints = 10,
                MagicPoints = 10,
                Level = 1,
                Experience = 0,
                Weapon = weapon,
                Armor = armor,
                Accessory = accessory,
            };
            
            context.Characters.Add(character);
            
            character = new Character
            {
                AppUser = kazner,
                Name = "Grugg",
                Class = characterClass,
                Strength = 1,
                Vigor = 1,
                Dexterity = 1,
                HitPoints = 10,
                MagicPoints = 10,
                Level = 1,
                Experience = 0,
                Weapon = weapon,
                Armor = armor,
                Accessory = accessory,
            };

            context.Characters.Add(character);
            // Store all the items added to the context
            context.SaveChanges();

        }
    }
}