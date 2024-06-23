using System.Collections.ObjectModel;
using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Repositories;
using Investment.App.Api.Models;
using Investment.App.Api.ViewModels.Customer;

namespace Investment.App.Api;

public class OperationService(ICustomerRepository _customerRepository, IFinancialProductRepository _financialProductRepository) : IOperationService
{
    public async Task<OperationResult> BuyAsync(BuyRequestViewModel request)
    {
        var customer = await _customerRepository.GetCustomerAsync();
        var financialProduct = await _financialProductRepository.GetByIdAsync(request.FinancialProductId);

        if (request.Amount > customer.AvailableAmount) return new() { IsValid = false, Message = "Not enough amount to buy" };
        if (request.Amount < financialProduct.MininumInvestment) return new() { IsValid = false, Message = "Your desired amount is lower than the minimum investment" };

        if (customer.Investments.Any(a => a.FinancialProductId == request.FinancialProductId))
        {
            var investment = customer.Investments.First(f => f.FinancialProductId == request.FinancialProductId);
            customer.AvailableAmount -= request.Amount;
            investment.UpdatedPurchaseAmount = investment.UpdatedPurchaseAmount + request.Amount;
            investment.Operations.Add(new()
            {
                Type = OperationType.BUY.ToString(),
                Amount = request.Amount,
                TimeStamp = DateTime.UtcNow,
                CustomerInvestmentId = investment.Id
            });
        }
        else
        {
            customer.AvailableAmount -= request.Amount;
            customer.Investments.Add(new()
            {
                CustomerId = customer.Id,
                FinancialProductId = request.FinancialProductId,
                InitialPurchaseAmount = request.Amount,
                UpdatedPurchaseAmount = request.Amount,
                Operations = new Collection<CustomerInvestmentOperation>(){
                    new(){
                        Type = OperationType.BUY.ToString(),
                        Amount = request.Amount,
                        TimeStamp = DateTime.UtcNow
                }}
            });
        }

        await _customerRepository.UpdateAsync(customer);

        return new()
        {
            IsValid = true
        };
    }

    public async Task<OperationResult> SellAsync(SellRequestViewModel request)
    {
        var customer = await _customerRepository.GetCustomerAsync();

        if (!customer.Investments.Any(a => a.FinancialProductId == request.FinancialProductId)) return new() { IsValid = false, Message = "Your investment was not found" };

        var investment = customer.Investments.First(f => f.FinancialProductId == request.FinancialProductId);

        if (request.Amount > investment.UpdatedPurchaseAmount) return new() { IsValid = false, Message = "You selected a value higher than you investment" };

        if (request.Amount == investment.UpdatedPurchaseAmount)
        {
            customer.AvailableAmount += investment.UpdatedPurchaseAmount;
            customer.Investments.Remove(investment);
        }
        else
        {
            customer.AvailableAmount += request.Amount;
            investment.UpdatedPurchaseAmount -= request.Amount;
            investment.Operations.Add(new()
            {
                Type = OperationType.SELL.ToString(),
                TimeStamp = DateTime.UtcNow,
                Amount = request.Amount
            });
        }

        await _customerRepository.UpdateAsync(customer);

        return new()
        {
            IsValid = true
        };
    }
}
