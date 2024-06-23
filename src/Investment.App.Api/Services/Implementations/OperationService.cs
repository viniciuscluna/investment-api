using Investment.App.Api.Models;
using Investment.App.Api.ViewModels.Customer;

namespace Investment.App.Api;

public class OperationService : IOperationService
{
    public async Task<OperationResult> BuyAsync(BuyRequestViewModel request)
    {
        throw new NotImplementedException();
    }

    public async Task<OperationResult> SellAsync(SellRequestViewModel request)
    {
        throw new NotImplementedException();
    }
}
