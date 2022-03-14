using ConsoleApp3;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var db = new ProductionContext();

await db.Database.EnsureDeletedAsync();

await db.Database.MigrateAsync();

var or = db.OrderRequirements.AsQueryable();
var gas = db.GrowerAssignmentsView(null, null, null, null).Where(x => x.GrowerCode == "GRW");
or = or.Where(x => gas.Any(y => y.CustomerCode == x.Customer.Code && y.Year == x.Year && y.WeekNumber == x.WeekNumber && y.FamilyCode == x.FamilyCode));

var programs = await or
    .GroupBy(x => new { CustomerCode = x.Customer.Code, CustomerDescription = x.Customer.Description, x.Year, x.WeekNumber, x.FamilyCode },
        (x, gr) => new { x.CustomerCode, x.CustomerDescription, x.Year, x.WeekNumber, x.FamilyCode, MaxArrivalDate = gr.SelectMany(o => o.OrderRequirementDetails.Select(d => d.ArrivalDate)).Max() })
    .ToListAsync();

Console.WriteLine("It works!");
Console.ReadKey(true);
