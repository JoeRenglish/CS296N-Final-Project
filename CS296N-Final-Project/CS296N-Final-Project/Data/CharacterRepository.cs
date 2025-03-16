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
                .Include(c => c.AppUser)
                .Include(c => c.Class);
        }
    }

    public IQueryable<Item> Items => _context.Items;
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

    

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await Items.Where(a => a.ItemId == id).FirstOrDefaultAsync();
    }

    public async Task<int> AddOrUpdateItemAsync(Item item)
    {
        _context.Items.Update(item);
        var result = await _context.SaveChangesAsync();
        return result;
    }

    public int DeleteItem(int itemId)
    {
        Item item = GetItemByIdAsync(itemId).Result;
        _context.Items.Remove(item);
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