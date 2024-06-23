using Investment.App.Api.Services;

namespace Investment.App.Api.Workers;

public class TimedInvestmentHostedService : IHostedService, IDisposable
{
    private readonly ILogger<TimedInvestmentHostedService> _logger;
    private Timer? _timer = null;
    private readonly IFinancialProductService _financialProductService;

    public TimedInvestmentHostedService(ILogger<TimedInvestmentHostedService> logger, IFinancialProductService financialProductService)
    {
        _logger = logger;
        _financialProductService = financialProductService;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromDays(1));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var availableProducts = _financialProductService.GetAllAvailableAsync().Result;
        var nextToExpire = availableProducts.Where(f => f.Expires >= DateTime.UtcNow && f.Expires <= DateTime.UtcNow.AddDays(5));

        if (nextToExpire.Any())
            //TODO: Implement email background task
            _logger.LogInformation(
            "There are investment next to expire");

        _logger.LogInformation(
            "Timed Hosted Service is working.");
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
