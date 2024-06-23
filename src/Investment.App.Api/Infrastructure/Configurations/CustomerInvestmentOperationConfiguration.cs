using Investment.App.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Investment.App.Api.Infrastructure.Configurations;

public class CustomerInvestmentOperationConfiguration : IEntityTypeConfiguration<CustomerInvestmentOperation>
{
    public void Configure(EntityTypeBuilder<CustomerInvestmentOperation> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).IsRequired().HasValueGenerator<SequentialGuidValueGenerator>();
        
        builder.Property(p => p.TimeStamp).IsRequired();
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.Type).IsRequired();
        builder.Property(p => p.CustomerInvestmentId).IsRequired();
    }

}
