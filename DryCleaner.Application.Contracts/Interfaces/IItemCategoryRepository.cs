using DryCleaner.Domain.Entities;

namespace DryCleaner.Application.Contracts.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с категориями изделий
/// </summary>
public interface IItemCategoryRepository : IRepository<ItemCategory>
{
}