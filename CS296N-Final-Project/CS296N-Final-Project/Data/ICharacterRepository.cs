using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public interface ICharacterRepository
{
    //Make the models Queryable
    IQueryable<Character> Characters { get; }
    IQueryable<Weapon> Weapons { get; }
    IQueryable<Armor> Armor { get; }
    IQueryable<Accessory> Accessories { get; }
    IQueryable<Consumable> Consumables { get; }
    IQueryable<Class> Classes { get; }
    
    //Find, Add, Update, and Delete Character
    public Task<Character?> GetCharacterByIdAsync(int id);
    public Task<int> AddOrUpdateCharacterAsync(Character character);
    public int DeleteCharacter(int characterId);

    //Find, Add, Update, and Delete Weapon
    public Task<Weapon?> GetWeaponByIdAsync(int id);
    public Task<int> AddOrUpdateWeaponAsync(Weapon weapon);
    public int DeleteWeapon(int weaponId);
    
    //Find, Add, Update, and Delete Armor
    public Task<Armor?> GetArmorByIdAsync(int id);
    public Task<int> AddOrUpdateArmorAsync(Armor armor);
    public int DeleteArmor(int armorId);
    
    //Find, Add, Update, and Delete Accessory
    public Task<Accessory?> GetAccessoryByIdAsync(int id);
    public Task<int> AddOrUpdateAccessoryAsync(Accessory accessory);
    public int DeleteAccessory(int accessoryId);
    
    //Find, Add, Update, and Delete Consumable
    public Task<Consumable?> GetConsumableByIdAsync(int id);
    public Task<int> AddOrUpdateConsumableAsync(Consumable consumable);
    public int DeleteConsumable(int consumableId);
    
    //Find, Add, Update, and Delete Class
    public Task<Class?> GetClassByIdAsync(int id);
    public Task<int> AddOrUpdateClassAsync(Class characterClass);
    public int DeleteClass(int classId);
}