using CS296N_Final_Project.Models;

namespace CS296N_Final_Project.Data;

public interface ICharacterRepository
{
    //Make the models Queryable
    IQueryable<Character> Characters { get; }
    IQueryable<Item> Items { get; }
    IQueryable<Class> Classes { get; }
    
    //Find, Add, Update, and Delete Character
    public Task<Character?> GetCharacterByIdAsync(int id);
    public Task<int> AddOrUpdateCharacterAsync(Character character);
    public int DeleteCharacter(int characterId);

    //Find, Add, Update, and Delete Item
    public Task<Item?> GetItemByIdAsync(int id);
    public Task<int> AddOrUpdateItemAsync(Item item);
    public int DeleteItem(int itemId);
    
    
    
    //Find, Add, Update, and Delete Class
    public Task<Class?> GetClassByIdAsync(int id);
    public Task<int> AddOrUpdateClassAsync(Class characterClass);
    public int DeleteClass(int classId);
}