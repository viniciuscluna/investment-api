namespace Investment.App.Api.ViewModels.Customer.Position;

public class PositionResponseViewModel
{
    public decimal AvailableAmount { get; set; }
    public PositionInvestmentResponseViewModel[] Investments { get; set; } = Array.Empty<PositionInvestmentResponseViewModel>();

}
