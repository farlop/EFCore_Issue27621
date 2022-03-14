using ConsoleApp3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp3.Configurations;

public class OrderRequirementConfiguration : IEntityTypeConfiguration<OrderRequirement>
{
    public void Configure(EntityTypeBuilder<OrderRequirement> builder)
    {
        builder.Property(x => x.FamilyCode)
            .HasMaxLength(50);

        builder.HasOne(x => x.Customer).WithMany().OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.OrderRequirementDetails).WithOne(x => x.OrderRequirement).OnDelete(DeleteBehavior.Cascade);
    }
}
