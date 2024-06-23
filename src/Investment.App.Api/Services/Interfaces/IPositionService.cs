namespace Investment.App.Api.Services;

public interface IPositionService
{
    Task<InvestmentPositionResponseViewModel[]> GetAsync();
}
