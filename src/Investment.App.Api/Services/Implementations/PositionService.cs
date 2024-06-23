
using Investment.App.Api.ViewModels.Customer.Position;

namespace Investment.App.Api.Services;

public class PositionService(ICustomerRepository _customerRepository) : IPositionService
{
    public async Task<PositionResponseViewModel> GetAsync()
    {
        var customer = await _customerRepository.GetCustomerAsync();

        return new()
        {
            AvailableAmount = customer.AvailableAmount,
            Investments = customer.Investments.Select(s => new PositionInvestmentResponseViewModel()
            {
                Investment = s.FinancialProduct?.Name ?? string.Empty,
                Amount = s.UpdatedPurchaseAmount,
                Updates = s.Operations.Select(s2 => new PositionInvestmentDetailResponseViewModel
                {
                    Amount = s2.Amount,
                    Operation = s2.Type,
                    TimeStamp = s2.TimeStamp
                }).ToArray()
            }).ToArray()
        };
    }
}
