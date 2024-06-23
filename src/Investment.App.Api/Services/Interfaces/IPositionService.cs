using Investment.App.Api.ViewModels.Customer.Position;

namespace Investment.App.Api.Services;

public interface IPositionService
{
    Task<PositionResponseViewModel> GetAsync();
}
