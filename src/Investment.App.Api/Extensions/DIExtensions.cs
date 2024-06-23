using Investment.App.Api.Infrastructure.Repositories;
using Investment.App.Api.Services;

namespace Investment.App.Api.Extensions;

public static class DIExtensions
{
    public static void AddServices(this IServiceCollection services){
        services.AddSingleton<ILoginService, LoginService>();
        services.AddScoped<IFinancialProductService, FinancialProductService>();
        services.AddScoped<IOperationService, OperationService>();
    }
    public static void AddRepositories(this IServiceCollection services){
        services.AddScoped<IFinancialProductRepository, FinancialProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerInvestmentRepository, CustomerInvestmentRepository>();
    }
}
