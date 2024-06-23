namespace Investment.App.Api;

public class InvestmentPositionResponseViewModel
{
    public required string Investment { get; set; }
    public decimal Amount { get; set; }

    public InvestmentPositionDetailResponseViewModel[] Updates { get; set; } = Array.Empty<InvestmentPositionDetailResponseViewModel>();
}

public class InvestmentPositionDetailResponseViewModel {
    public required string Operation { get; set; }
    public decimal Amount { get; set; }
    public DateTime TimeStamp { get; set; }
}
