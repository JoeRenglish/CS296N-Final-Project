using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public interface ICharacterRepository
{
    IQueryable<Character> Characters { get; }
    public Task<Character?> GetCharacterByIdAsync(int id);
    public Task<int> AddOrUpdateCharacterAsync(Character character);
    public int DeleteCharacter(int characterId);
}