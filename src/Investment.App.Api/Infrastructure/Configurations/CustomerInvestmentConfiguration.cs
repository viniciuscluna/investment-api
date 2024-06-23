using Investment.App.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Investment.App.Api.Infrastructure.Configurations;

public class CustomerInvestmentConfiguration : IEntityTypeConfiguration<CustomerInvestment>
{
    public void Configure(EntityTypeBuilder<CustomerInvestment> builder){

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).IsRequired().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(p => p.InitialPurchaseAmount).IsRequired();
        builder.Property(p => p.UpdatedPurchaseAmount).IsRequired();
        builder.Property(p => p.FinancialProductId).IsRequired();

        builder.HasMany(o => o.Operations)
            .WithOne(o => o.CustomerInvestment)
            .HasForeignKey(o => o.CustomerInvestmentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasPrincipalKey(o => o.Id);
    }

}
