namespace DryCleaner.Application.Contracts.DTOs;

/// <summary>
/// DTO изделия
/// </summary>
/// <param name="Id">Идентификатор изделия</param>
/// <param name="Name">Название изделия</param>
/// <param name="Category">Категория изделия</param>
/// <param name="CategoryId">Идентификатор категории изделия</param>
/// <param name="Material">Материал изделия</param>
public record ItemDto(
    int Id,
    string Name,
    ItemCategoryDto Category,
    int CategoryId,
    string Material
);