using ConsoleApp3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp3.Configurations;

public class GrowerAssignmentViewConfiguration : IEntityTypeConfiguration<GrowerAssignmentView>
{
    public void Configure(EntityTypeBuilder<GrowerAssignmentView> builder)
    {
        builder.HasNoKey();       
    }
}
