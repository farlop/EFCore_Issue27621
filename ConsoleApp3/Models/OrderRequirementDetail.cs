namespace ConsoleApp3.Models;

public class OrderRequirementDetail
{
    public int Id { get; private set; }

    public int OrderRequirementId { get; private set; }

    public virtual OrderRequirement OrderRequirement { get; private set; }

    public DateTime ArrivalDate { get; private set; }


    public OrderRequirementDetail(DateTime arrivalDate)
    {       
        ArrivalDate = arrivalDate;        
    }
}
