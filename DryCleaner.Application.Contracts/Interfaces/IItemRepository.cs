using DryCleaner.Domain.Entities;

namespace DryCleaner.Application.Contracts.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с изделиями
/// </summary>
public interface IItemRepository : IRepository<Item>
{
}