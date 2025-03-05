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
}