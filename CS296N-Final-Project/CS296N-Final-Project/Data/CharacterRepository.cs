using CS296N_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CS296N_Final_Project.Data;

public class CharacterRepository : ICharacterRepository
{
    private readonly ApplicationDbContext _context;

    public CharacterRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public IQueryable<Character> Characters
    {
        get
        {
            return _context.Characters
                .Include(c => c.Stats)
                .Include(c => c.Equipment)
                .ThenInclude(e => e.Weapon)
                .Include(e => e.Equipment)
                .ThenInclude(e => e.Armor)
                .Include(e => e.Equipment)
                .ThenInclude(e => e.Accessory)
                .Include(e => e.Equipment)
                .ThenInclude(e => e.Consumable)
                .Include(c => c.Class);
        }
    }

    public IQueryable<Weapon> Weapons { get; }
    public IQueryable<Armor> Armor { get; }
    public IQueryable<Accessory> Accessories { get; }
    public IQueryable<Consumable> Consumables { get; }
    public IQueryable<Class> Classes { get; }


    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await Characters.Where(c => c.CharacterId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateCharacterAsync(Character character)
    {
        _context.Characters.Update(character);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteCharacter(int characterId)
    {
        Character character = GetCharacterByIdAsync(characterId).Result;
        _context.Characters.Remove(character);
        return _context.SaveChanges();
    }

    public Task<Weapon?> GetWeaponByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateWeaponAsync(Weapon weapon)
    {
        throw new NotImplementedException();
    }

    public int DeleteWeapon(int weaponId)
    {
        throw new NotImplementedException();
    }

    public Task<Armor?> GetArmorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateArmorAsync(Armor armor)
    {
        throw new NotImplementedException();
    }

    public int DeleteArmor(int armorId)
    {
        throw new NotImplementedException();
    }

    public Task<Accessory?> GetAccessoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateAccessoryAsync(Accessory accessory)
    {
        throw new NotImplementedException();
    }

    public int DeleteAccessory(int accessoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Consumable?> GetConsumableByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateConsumableAsync(Consumable consumable)
    {
        throw new NotImplementedException();
    }

    public int DeleteConsumable(int consumableId)
    {
        throw new NotImplementedException();
    }

    public Task<Class?> GetClassByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateClassAsync(Class characterClass)
    {
        throw new NotImplementedException();
    }

    public int DeleteClass(int classId)
    {
        throw new NotImplementedException();
    }
}