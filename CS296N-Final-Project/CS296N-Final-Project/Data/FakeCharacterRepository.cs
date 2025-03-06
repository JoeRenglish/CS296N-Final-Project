using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public class FakeCharacterRepository : ICharacterRepository
{
    public IQueryable<Character> Characters { get; }
    public IQueryable<Weapon> Weapons { get; }
    public IQueryable<Armor> Armor { get; }
    public IQueryable<Accessory> Accessories { get; }
    public IQueryable<Consumable> Consumables { get; }
    public IQueryable<Class> Classes { get; }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public int DeleteCharacter(int characterId)
    {
        throw new NotImplementedException();
    }

    public async Task<Weapon?> GetWeaponByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateWeaponAsync(Weapon weapon)
    {
        throw new NotImplementedException();
    }

    public int DeleteWeapon(int weaponId)
    {
        throw new NotImplementedException();
    }

    public async Task<Armor?> GetArmorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateArmorAsync(Armor armor)
    {
        throw new NotImplementedException();
    }

    public int DeleteArmor(int armorId)
    {
        throw new NotImplementedException();
    }

    public async Task<Accessory?> GetAccessoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateAccessoryAsync(Accessory accessory)
    {
        throw new NotImplementedException();
    }

    public int DeleteAccessory(int accessoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<Consumable?> GetConsumableByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateConsumableAsync(Consumable consumable)
    {
        throw new NotImplementedException();
    }

    public int DeleteConsumable(int consumableId)
    {
        throw new NotImplementedException();
    }

    public async Task<Class?> GetClassByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddOrUpdateClassAsync(Class characterClass)
    {
        throw new NotImplementedException();
    }

    public int DeleteClass(int classId)
    {
        throw new NotImplementedException();
    }
}