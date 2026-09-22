namespace DryCleaner.Domain.Entities;

/// <summary>
/// Изделие в химчистке
/// </summary>
public class Item
{
    public required string Name { get; set; }
    public required ItemCategory Category { get; set; }
    public required string Material { get; set; }
}