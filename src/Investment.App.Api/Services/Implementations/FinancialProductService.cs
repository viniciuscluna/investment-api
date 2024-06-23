using AutoMapper;
using Investment.App.Api.Infrastructure.Repositories;
using Investment.App.Api.ViewModels;

namespace Investment.App.Api.Services;

public class FinancialProductService(IMapper _mapper, IFinancialProductRepository _repository) : IFinancialProductService
{
    public async Task<ICollection<FinancialProductViewModel>> GetAllAsync()
    {
        var availableProducts = await _repository.GetAllAvailableAsync();
        return _mapper.Map<ICollection<FinancialProductViewModel>>(availableProducts);
    }
}
