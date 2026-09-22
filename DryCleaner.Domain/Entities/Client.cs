namespace DryCleaner.Domain.Entities;

/// <summary>
/// Клиент химчистки
/// </summary>
public class Client
{
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
}