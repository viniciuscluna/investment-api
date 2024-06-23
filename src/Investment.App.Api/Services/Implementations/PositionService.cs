
using Microsoft.Extensions.Caching.Memory;

namespace Investment.App.Api.Services;

public class PositionService(ICustomerRepository _customerRepository, IMemoryCache _memoryCache) : IPositionService
{
    public async Task<InvestmentPositionResponseViewModel[]> GetAsync()
    {
        const string customerKey = "INVESTMENT_KEY";

        if (_memoryCache.TryGetValue(customerKey, out InvestmentPositionResponseViewModel[] memory))
        {
            return memory;
        }

        var customer = await _customerRepository.GetCustomerAsync();

        var result = customer.Investments.Select(s => new InvestmentPositionResponseViewModel()
        {
            Investment = s.FinancialProduct?.Name ?? string.Empty,
            Amount = s.UpdatedPurchaseAmount,
            Updates = s.Operations.Select(s2 => new InvestmentPositionDetailResponseViewModel
            {
                Amount = s2.Amount,
                Operation = s2.Type,
                TimeStamp = s2.TimeStamp
            }).ToArray()
        }).ToArray();

        _memoryCache.GetOrCreate(customerKey, entry =>
           {
               entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
               entry.SetPriority(CacheItemPriority.High);

               return result;
           });

        return result;
    }
}
