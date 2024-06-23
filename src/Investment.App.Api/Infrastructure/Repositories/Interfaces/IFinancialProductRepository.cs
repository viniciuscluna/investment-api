using Investment.App.Api.Entities;

namespace Investment.App.Api.Infrastructure.Repositories;

public interface IFinancialProductRepository : IGenericRepository<FinancialProduct>
{
    Task<IList<FinancialProduct>> GetAllAvailableAsync();
}
