using System.ComponentModel.DataAnnotations;
using DryCleaner.Shared.Enums;

namespace DryCleaner.Application.Contracts.DTOs;

/// <summary>
/// DTO дл€ создани€ или обновлени€ категории издели€
/// </summary>
/// <param name="Name">Ќазвание категории</param>
/// <param name="RecommendedCleaning">–екомендуемый вид чистки</param>
/// <param name="Price">—тоимость обработки</param>
public record ItemCategoryCreateUpdateDto(
    [Required(ErrorMessage = "Ќазвание категории об€зательно дл€ заполнени€!")]
    string Name,

    CleaningType RecommendedCleaning,

    decimal Price
);