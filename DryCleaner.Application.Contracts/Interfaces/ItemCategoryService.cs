using DryCleaner.Application.Contracts.DTOs;

namespace DryCleaner.Application.Contracts.Interfaces;

public interface IItemCategoryService
    : IApplicationService<ItemCategoryDto, ItemCategoryCreateUpdateDto, int>
{
}