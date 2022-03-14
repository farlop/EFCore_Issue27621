using ConsoleApp3.Configurations;
using ConsoleApp3.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp3;

public class ProductionContext : DbContext
{
    public ProductionContext() { }

    public ProductionContext([NotNull] DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<OrderRequirement> OrderRequirements { get; set; }


    public IQueryable<GrowerAssignmentView> GrowerAssignmentsView(string customerCode = null, int? year = null, int? weekNumber = null, string familyCode = null) =>
        FromExpression(() => GrowerAssignmentsView(customerCode, year, weekNumber, familyCode));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderRequirementConfiguration());
        modelBuilder.ApplyConfiguration(new OrderRequirementDetailConfiguration());
        modelBuilder.ApplyConfiguration(new GrowerAssignmentViewConfiguration());

        modelBuilder.HasDbFunction(() => GrowerAssignmentsView(default, default, default, default))
            .HasName("fGrowerAssignments");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Initial Catalog=EFCore_Issue27621;Integrated Security=true;Encrypt=false", sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
    }
}
