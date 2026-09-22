using DryCleaner.Domain.Enums;

namespace DryCleaner.Domain.Entities;

/// <summary>
/// Категория изделия
/// </summary>
public class ItemCategory
{
    public required string Name { get; set; }
    public CleaningType RecommendedCleaning { get; set; }
    public int Price { get; set; }
}