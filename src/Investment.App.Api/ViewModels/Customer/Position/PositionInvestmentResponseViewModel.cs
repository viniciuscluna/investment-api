namespace Investment.App.Api.ViewModels.Customer.Position;

public class PositionInvestmentResponseViewModel
{
    public required string Investment { get; set; }
    public decimal Amount { get; set; }

    public PositionInvestmentDetailResponseViewModel[] Updates { get; set; } = Array.Empty<PositionInvestmentDetailResponseViewModel>();
}

public class PositionInvestmentDetailResponseViewModel {
    public required string Operation { get; set; }
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
}
