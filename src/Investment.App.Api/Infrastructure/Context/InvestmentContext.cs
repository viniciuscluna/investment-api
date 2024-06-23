using Investment.App.Api.Entities;
using Investment.App.Api.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Investment.App.Api.Infrastructure.Context;

public class InvestmentContext : DbContext
{
    public InvestmentContext(DbContextOptions<InvestmentContext> options) : base(options)
    {
    }

    public DbSet<CustomerInvestment> CustomerInvestments { get; set; }
    public DbSet<CustomerInvestmentOperation> CustomerInvestmentOperations { get; set; }
    public DbSet<FinancialProduct> FinancialProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerInvestmentConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerInvestmentOperationConfiguration());
        modelBuilder.ApplyConfiguration(new FinancialProductConfiguration());
    }
}
