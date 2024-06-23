namespace Investment.App.Api.ViewModels.Admin;

public class UpdateProductViewModel
{
    public bool? Enabled { get; set; }
    public decimal? MinimumInvestment { get; set; }
    public int? RiskLevel { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? Expires { get; set; }
}
