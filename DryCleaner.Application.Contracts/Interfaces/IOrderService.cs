using DryCleaner.Application.Contracts.DTOs;

namespace DryCleaner.Application.Contracts.Interfaces;

public interface IOrderService
    : IApplicationService<OrderDto, OrderCreateUpdateDto, int>
{
}