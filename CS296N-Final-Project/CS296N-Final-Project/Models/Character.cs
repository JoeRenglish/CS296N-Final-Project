namespace CS296N_Final_Project.Models;

public class Character
{
    public int CharacterId { get; set; }
    
    public AppUser? AppUser { get; set; }
    
    public string? Name { get; set; }
    
   public Stats? Stats { get; set; }
    
    public Equipment? Equipment { get; set; }
    
    public Class? Class { get; set; }
    
    public int StatsId { get; set; }
  
    public int EquipmentId { get; set; }
    
}