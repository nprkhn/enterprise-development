using DryCleaner.Domain.Entities;

namespace DryCleaner.Application.Contracts.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с заказами
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
}