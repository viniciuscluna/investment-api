using System.Collections.ObjectModel;

namespace Investment.App.Api.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal AvailableAmount { get; set; }

    public ICollection<CustomerInvestment> Investments { get; set; } = new Collection<CustomerInvestment>();
}
