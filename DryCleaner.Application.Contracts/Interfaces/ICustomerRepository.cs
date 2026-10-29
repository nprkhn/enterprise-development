using DryCleaner.Domain.Entities;

namespace DryCleaner.Application.Contracts.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с клиентами
/// </summary>
public interface ICustomerRepository : IRepository<Customer>
{
}