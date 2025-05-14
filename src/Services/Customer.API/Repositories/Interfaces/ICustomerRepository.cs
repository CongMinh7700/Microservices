using Contracts.Common.Interfaces;
using Customer.API.Persistence;

namespace Customer.API.Repositories.Interfaces;

using Entities;

public interface ICustomerRepository : IRepositoryBaseAsync<Customer, int, CustomerContext>
{
    Task<Customer> GetCustomerByUsernameAsync(string userName);
    Task<Customer> GetCustomerByUserIdAsync(int userId);
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int userId);
    Task<IEnumerable<Customer>> GetCustomersAsync();
}
