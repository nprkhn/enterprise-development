using DryCleaner.Application.Contracts.DTOs;

namespace DryCleaner.Application.Contracts.Interfaces;

public interface IItemService
    : IApplicationService<ItemDto, ItemCreateUpdateDto, int>
{
}