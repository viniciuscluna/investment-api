using System.Collections.ObjectModel;

namespace Investment.App.Api.Entities;

public class FinancialProduct
{    
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool Enabled { get; set; }
    public DateTime Expires { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int RiskLevel { get; set; }
    public decimal MininumInvestment { get; set; }

    public ICollection<CustomerInvestment> Investments { get; set; } = new Collection<CustomerInvestment>();
}
