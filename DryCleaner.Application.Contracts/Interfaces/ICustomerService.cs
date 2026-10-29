using DryCleaner.Application.Contracts.DTOs;

namespace DryCleaner.Application.Contracts.Interfaces;

public interface ICustomerService
    : IApplicationService<CustomerDto, CustomerCreateUpdateDto, int>
{
}