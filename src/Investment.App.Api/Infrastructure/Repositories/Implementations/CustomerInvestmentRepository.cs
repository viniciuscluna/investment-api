using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Context;

namespace Investment.App.Api.Infrastructure.Repositories;

public class CustomerInvestmentRepository: GenericRepository<CustomerInvestment>, ICustomerInvestmentRepository
{
    private readonly InvestmentDbContext _context;
    public CustomerInvestmentRepository(InvestmentDbContext context)
    :base(context)
    {
        _context = context;
    }
}
