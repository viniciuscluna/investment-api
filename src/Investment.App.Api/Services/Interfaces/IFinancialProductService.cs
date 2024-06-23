using Investment.App.Api.ViewModels;
using Investment.App.Api.ViewModels.Admin;

namespace Investment.App.Api.Services;

public interface IFinancialProductService
{
    Task<ICollection<FinancialProductViewModel>> GetAllAvailableAsync();
    Task<ICollection<FinancialProductViewModel>> GetAllAsync();
    Task UpdateAsync(Guid productId, UpdateProductViewModel viewModel);
}
