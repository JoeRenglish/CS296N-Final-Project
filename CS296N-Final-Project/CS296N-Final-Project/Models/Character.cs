namespace CS296N_Final_Project.Models;

public class Character
{
    public int CharacterId { get; set; }
    
    public AppUser? AppUser { get; set; }
    
    public string? Name { get; set; }
    
    public int Attack { get; set; }
    
    public int Defense { get; set; }
    
    public int Speed { get; set; }
    
    public int HitPoints { get; set; }
    
    public Equipment? Equipment { get; set; }
    
    public Class? Class { get; set; }
    
    
    public int ClassId { get; set; }
    public int EquipmentId { get; set; }
    
}