using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public class FakeCharacterRepository : ICharacterRepository
{
    public IQueryable<Character> Characters { get; }
    
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
}