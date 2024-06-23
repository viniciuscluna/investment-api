using Investment.App.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Investment.App.Api.Infrastructure.Configurations;

public class FinancialProductConfiguration : IEntityTypeConfiguration<FinancialProduct>
{
    public void Configure(EntityTypeBuilder<FinancialProduct> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().HasValueGenerator<SequentialGuidValueGenerator>();
        
        builder.Property(p => p.TimeStamp).IsRequired();

        builder.Property(p => p.Enabled).IsRequired().HasDefaultValue(true);

        builder.Property(p => p.Expires).IsRequired();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

        builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

        builder.Property(p => p.RiskLevel).IsRequired();

        builder.Property(p => p.MininumInvestment).IsRequired();

        builder.HasMany(e => e.Investments)
            .WithOne(e => e.FinancialProduct)
            .HasForeignKey(e => e.FinancialProductId)
            .HasPrincipalKey(e => e.Id);

        builder.HasData([
            new(){
                Id = Guid.NewGuid(),
                Enabled = true,
                Name = "CDB",
                Description = "CDB Loren Ipsun",
                Expires = DateTime.UtcNow.AddMonths(5),
                RiskLevel = 5,
                MininumInvestment = 50,
                TimeStamp = DateTime.UtcNow
            },
            new(){
                Id = Guid.NewGuid(),
                Enabled = true,
                Name = "LCI",
                Description = "LCI Loren Ipsun",
                Expires = DateTime.UtcNow.AddMonths(6),
                RiskLevel = 5,
                MininumInvestment = 500,
                TimeStamp = DateTime.UtcNow
            },
            new(){
                Id = Guid.NewGuid(),
                Enabled = true,
                Name = "LCA",
                Description = "LCA Loren Ipsun",
                Expires = DateTime.UtcNow.AddDays(6),
                RiskLevel = 5,
                MininumInvestment = 1000,
                TimeStamp = DateTime.UtcNow
            },
        ]);

    }
}
