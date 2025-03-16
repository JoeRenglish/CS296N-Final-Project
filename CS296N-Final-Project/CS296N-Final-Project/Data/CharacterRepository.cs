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

    public IQueryable<Weapon> Weapons => _context.Weapons;
    public IQueryable<Armor> Armor => _context.Armor;
    public IQueryable<Accessory> Accessories => _context.Accessories;
    public IQueryable<Consumable> Consumables => _context.Consumables;
    public IQueryable<Class> Classes => _context.Classes;


    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await Characters.Where(c => c.CharacterId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateCharacterAsync(Character character)
    {
        _context.Characters.Update(character);
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result;
    }

    public int DeleteCharacter(int characterId)
    {
        Character character = GetCharacterByIdAsync(characterId).Result;
        _context.Characters.Remove(character);
        return _context.SaveChanges();
    }

    public async Task<Weapon?> GetWeaponByIdAsync(int id)
    {
        return await Weapons.Where(w => w.WeaponId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateWeaponAsync(Weapon weapon)
    {
        _context.Weapons.Update(weapon);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteWeapon(int weaponId)
    {
        Weapon weapon = GetWeaponByIdAsync(weaponId).Result;
        _context.Weapons.Remove(weapon);
        return _context.SaveChanges();
    }

    public async Task<Armor?> GetArmorByIdAsync(int id)
    {
        return await Armor.Where(a => a.ArmorId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateArmorAsync(Armor armor)
    {
        _context.Armor.Update(armor);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteArmor(int armorId)
    {
        Armor armor = GetArmorByIdAsync(armorId).Result;
        _context.Armor.Remove(armor);
        return _context.SaveChanges();
    }

    public async Task<Accessory?> GetAccessoryByIdAsync(int id)
    {
        return await Accessories.Where(a => a.AccessoryId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateAccessoryAsync(Accessory accessory)
    {
        _context.Accessories.Update(accessory);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteAccessory(int accessoryId)
    {
        Accessory accessory = GetAccessoryByIdAsync(accessoryId).Result;
        _context.Accessories.Remove(accessory);
        return _context.SaveChanges();
    }

    public async Task<Consumable?> GetConsumableByIdAsync(int id)
    {
        return await Consumables.Where(c => c.ConsumableId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateConsumableAsync(Consumable consumable)
    {
        _context.Consumables.Update(consumable);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteConsumable(int consumableId)
    {
        Consumable consumable = GetConsumableByIdAsync(consumableId).Result;
        _context.Consumables.Remove(consumable);
        return _context.SaveChanges();
    }

    public async Task<Class?> GetClassByIdAsync(int id)
    {
        return await Classes.Where(c => c.ClassId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateClassAsync(Class characterClass)
    {
        _context.Classes.Update(characterClass);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteClass(int classId)
    {
        Class characterClass = GetClassByIdAsync(classId).Result;
        _context.Classes.Remove(characterClass);
        return _context.SaveChanges();
    }
}