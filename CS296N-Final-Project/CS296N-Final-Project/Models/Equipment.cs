namespace CS296N_Final_Project.Models;

public class Equipment
{
    public int EquipmentId { get; set; }
    
    public int CharacterId { get; set; }
    
    public Weapon? Weapon { get; set; }
    
    public Armor? Armor { get; set; }
    
    public Accessory? Accessory { get; set; }
    
    public Consumable? Consumable { get; set; }
}