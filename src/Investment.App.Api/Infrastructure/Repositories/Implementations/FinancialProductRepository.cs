using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Investment.App.Api.Infrastructure.Repositories;

public class FinancialProductRepository : GenericRepository<FinancialProduct>, IFinancialProductRepository
{
    private readonly InvestmentDbContext _context;
    public FinancialProductRepository(InvestmentDbContext context)
    :base(context)
    {
        _context = context;
    }
    public async Task<IList<FinancialProduct>> GetAllAvailableAsync()
    {
        return await _context.FinancialProducts.Where(f => f.Enabled && f.Expires > DateTime.UtcNow).OrderBy(o => o.Name).ToListAsync();
    }
}
