using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Repositories;

namespace Investment.App.Api;

public interface ICustomerRepository  : IGenericRepository<Customer>
{
    Task<Customer> GetCustomerAsync();
}
