using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Context;
using Investment.App.Api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Investment.App.Api;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
    private readonly InvestmentDbContext _context;
    public CustomerRepository(InvestmentDbContext context)
    :base(context)
    {
        _context = context;
    }

    /// <summary>
    /// For now, this method only returns the first customer ocorrence on database due to missing identity provider
    /// </summary>
    /// <returns>the first customer</returns>
    public async Task<Customer> GetCustomer()
    {
        return await _context.Customers.FirstAsync();
    }
}
