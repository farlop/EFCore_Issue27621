namespace ConsoleApp3.Models;

public class OrderRequirement
{
    public int Id { get; private set; }

    public int CustomerId { get; private set; }

    public virtual Customer Customer { get; private set; }

    public int Year { get; private set; }

    public int WeekNumber { get; private set; }    

    public string FamilyCode { get; private set; }

    private readonly List<OrderRequirementDetail> _orderRequirementDetails;

    public IEnumerable<OrderRequirementDetail> OrderRequirementDetails => _orderRequirementDetails.AsReadOnly();

    public OrderRequirement()
    {
        _orderRequirementDetails = new List<OrderRequirementDetail>();
    }

    public OrderRequirement(int customerId, int year, int weekNumber, string familyCode) : this()
    {
        CustomerId = customerId;
        Year = year;
        WeekNumber = weekNumber;
        FamilyCode = familyCode;
    }

    public void AddDetails(params OrderRequirementDetail[] details) => _orderRequirementDetails.AddRange(details);
}
