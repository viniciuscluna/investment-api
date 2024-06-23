namespace Investment.App.Api.ViewModels;

public class FinancialProductViewModel
{
        public Guid Id { get; set; }
        public DateTime Expires { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int RiskLevel { get; set; }
        public decimal MininumInvestment { get; set; }
}
