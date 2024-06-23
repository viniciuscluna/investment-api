using Investment.App.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Investment.App.Api;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder){

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).IsRequired().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.AvailableAmount).IsRequired();

        builder.HasMany(o => o.Investments)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasPrincipalKey(o => o.Id);

        builder.HasData([
            new(){
                Id = Guid.NewGuid(),
                Name = "User 1",
                AvailableAmount = 5000
            }
        ]);
    }

}
