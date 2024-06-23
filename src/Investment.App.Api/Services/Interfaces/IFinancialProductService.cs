using Investment.App.Api.ViewModels;

namespace Investment.App.Api.Services;

public interface IFinancialProductService
{
    Task<ICollection<FinancialProductViewModel>> GetAllAsync();
}
