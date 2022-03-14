using ConsoleApp3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp3.Configurations;

public class OrderRequirementDetailConfiguration : IEntityTypeConfiguration<OrderRequirementDetail>
{
    public void Configure(EntityTypeBuilder<OrderRequirementDetail> builder)
    {
        builder.ToTable("OrderRequirementDetails");

        builder.HasKey(x => x.Id); 

        builder.Property(x => x.ArrivalDate).HasColumnType("date");

        builder.HasOne(x => x.OrderRequirement).WithMany(x => x.OrderRequirementDetails).OnDelete(DeleteBehavior.Cascade);
    }
}
