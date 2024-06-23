using System.Collections.ObjectModel;

namespace Investment.App.Api.Entities;

public class CustomerInvestment
{
    public Guid Id { get; set; }
    public Guid FinancialProductId { get; set; }
    public FinancialProduct? FinancialProduct { get; set; }
    public Guid CustomerId { get; set; }
    public decimal InitialPurchaseAmount { get; set; }
    public decimal UpdatedPurchaseAmount { get; set; }
    public Customer? Customer { get; set; }
    public ICollection<CustomerInvestmentOperation> Operations { get; set; } = new Collection<CustomerInvestmentOperation>();

}
