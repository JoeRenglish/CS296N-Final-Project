namespace CS296N_Final_Project.Models;

public class Consumable
{
    public int ConsumableId { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? Effect { get; set; }
    
    public int HealValue { get; set; }
}