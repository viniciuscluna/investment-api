namespace Investment.App.Api.Entities;

public class CustomerInvestmentOperation
{
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public Guid CustomerInvestmentId { get; set; }
    public CustomerInvestment? CustomerInvestment { get; set; } 
    public required string Type { get; set; }    
    public decimal Amount { get; set; }   

}
