using System.ComponentModel.DataAnnotations;

namespace DryCleaner.Application.Contracts.DTOs;

/// <summary>
/// DTO для создания или обновления клиента
/// </summary>
/// <param name="LastName">Фамилия клиента</param>
/// <param name="FirstName">Имя клиента</param>
/// <param name="Patronymic">Отчество клиента</param>
/// <param name="PhoneNumber">Номер телефона клиента</param>
public record CustomerCreateUpdateDto(
    [Required(ErrorMessage = "Имя клиента обязательно для заполнения!")]
    string FirstName,

    string? Patronymic,

    [Required(ErrorMessage = "Фамилия клиента обязательна для заполнения!")]
    string LastName,

    [Required(ErrorMessage = "Номер телефона обязателен для заполнения!")]
    [RegularExpression(@"^\+?[0-9()\-\s]{5,20}$", ErrorMessage = "Некорректный номер телефона!")]
    string PhoneNumber
);