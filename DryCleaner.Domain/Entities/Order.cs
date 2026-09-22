using DryCleaner.Domain.Enums;

namespace DryCleaner.Domain.Entities;

/// <summary>
/// Заказ на химчистку
/// </summary>
public class Order
{
    public required Client Client { get; set; }
    public required Item Item { get; set; }
    public DateTime AcceptanceDate { get; set; }
    public int CompletionDays { get; set; }
    public OrderStatus Status { get; set; }
}