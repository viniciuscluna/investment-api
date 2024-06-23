using AutoMapper;
using Investment.App.Api.Infrastructure.Repositories;
using Investment.App.Api.ViewModels;
using Investment.App.Api.ViewModels.Admin;

namespace Investment.App.Api.Services;

public class FinancialProductService(IMapper _mapper, IFinancialProductRepository _repository) : IFinancialProductService
{
    public async Task<ICollection<FinancialProductViewModel>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<ICollection<FinancialProductViewModel>>(products);
    }

    public async Task<ICollection<FinancialProductViewModel>> GetAllAvailableAsync()
    {
        var availableProducts = await _repository.GetAllAvailableAsync();
        return _mapper.Map<ICollection<FinancialProductViewModel>>(availableProducts);
    }

    public async Task UpdateAsync(Guid productId, UpdateProductViewModel viewModel)
    {
        var product = await _repository.GetByIdAsync(productId);

        if (viewModel.Enabled.HasValue)
            product.Enabled = viewModel.Enabled.Value;

        if (viewModel.RiskLevel.HasValue)
            product.RiskLevel = viewModel.RiskLevel.Value;

        if (!string.IsNullOrEmpty(viewModel.Name))
            product.Name = viewModel.Name;

        if (!string.IsNullOrEmpty(viewModel.Description))
            product.Description = viewModel.Description;

        if(viewModel.MinimumInvestment.HasValue)
            product.MininumInvestment = viewModel.MinimumInvestment.Value;
        
        if(viewModel.Expires.HasValue)
            product.Expires = viewModel.Expires.Value;  

        await _repository.UpdateAsync(product);
    }
}
