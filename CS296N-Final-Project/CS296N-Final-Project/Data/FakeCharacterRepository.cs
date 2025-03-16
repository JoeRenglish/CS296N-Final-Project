using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public class FakeCharacterRepository : ICharacterRepository
{
    public IQueryable<Character> Characters { get; }
    public IQueryable<Item> Items { get; }
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

    public Task<Item?> GetItemByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public int DeleteItem(int itemId)
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