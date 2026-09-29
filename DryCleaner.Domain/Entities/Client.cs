namespace DryCleaner.Domain.Entities;

/// <summary>
/// Клиент химчистки
/// </summary>
public class Costumer
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя клиента
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Отчество клиента
    /// </summary>
    public required string MiddleName { get; set; }
    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string PhoneNumber { get; set; }
}