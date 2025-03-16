namespace CS296N_Final_Project.Models;

public class Item
{
    public int ItemId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Category { get; set; }
    
    public string? Effect { get; set; }
    
    public string? Element { get; set; }
    
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public int SpeedValue { get; set; }
    public int HealValue { get; set; }
}