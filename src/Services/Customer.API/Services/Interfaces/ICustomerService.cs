using Shared.DTOs.Customers;

namespace Customer.API.Services.Interfaces;

public interface ICustomerService
{
    Task<IResult> GetCustomerByUsernameAsync(string username);

    Task<IResult> GetCustomerByUserIdAsync(int userId);

    Task<IResult> GetCustomersAsync();

    Task<IResult> CreateCustomerAsync(CreateCustomerDto createDto);

    Task<IResult> UpdateCustomerAsync(int userId, UpdateCustomerDto updateDto);

    Task<IResult> DeleteCustomerAsync(int userId);
}
