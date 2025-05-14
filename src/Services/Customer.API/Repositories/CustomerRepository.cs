using Contracts.Common.Interfaces;
using Customer.API.Persistence;
using Customer.API.Repositories.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Repositories;

using Entities;

public class CustomerRepository : RepositoryBaseAsync<Customer, int, CustomerContext>, ICustomerRepository
{
    public CustomerRepository(CustomerContext dbContext,
        IUnitOfWork<CustomerContext> unitOfWork) : base(dbContext, unitOfWork)
    {

    }

    public Task CreateCustomerAsync(Customer customer)
        => CreateAsync(customer);

    public async Task DeleteCustomerAsync(int userId)
    {
        var customer = await GetCustomerByUserIdAsync(userId);
        if (customer != null)
        {
            DeleteAsync(customer);
        }
    }

    public Task<Customer> GetCustomerByUsernameAsync(string userName)
        => FindByCondition(p => p.UserName.Equals(userName)).SingleOrDefaultAsync();

    public Task<Customer> GetCustomerByUserIdAsync(int userId)
        => FindByCondition(p => p.Id.Equals(userId)).SingleOrDefaultAsync();

    public async Task<IEnumerable<Customer>> GetCustomersAsync() =>
    await FindAll().ToListAsync();

    public Task UpdateCustomerAsync(Customer customer)
   => UpdateAsync(customer);
}
