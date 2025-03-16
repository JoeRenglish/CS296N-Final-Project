namespace CS296N_Final_Project.Models;

public class Character
{
    private readonly List<Item> items = new();
    public int CharacterId { get; set; }
    
    public AppUser? AppUser { get; set; }
    
    public string? Name { get; set; }
    
    public int Gold { get; set; }
    
    public int Experience { get; set; }
    
    public int Level { get; set; }
    
    public int Strength { get; set; }
    public int Vigor { get; set; }
    public int Dexterity { get; set; }
    public int HitPoints { get; set; }
    public int MagicPoints { get; set; }
    
    public Item? Weapon { get; set; }
    public Item? Armor { get; set; }
    public Item? Accessory { get; set; }
    public Class? Class { get; set; }

    private ICollection<Item>? Items => items;
}