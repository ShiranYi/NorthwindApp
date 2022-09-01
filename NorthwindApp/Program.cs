using NorthwindApp;
using NorthwindApp.Models;

var db = new NorthwindContext();
// q1
var regionList = db.Regions.OrderBy(r => r.RegionDescription).ToList();

// q2
Console.WriteLine("Region Description:");
foreach (var region in regionList)
{
    Console.WriteLine(region.RegionDescription);
}

// q3
var territoryList = from territory in db.Territories
                    orderby territory.TerritoryDescription
                    select territory;

// q4
Console.WriteLine("\nTerritory Description:");
foreach (var territory in territoryList)
{
    Console.WriteLine(territory.TerritoryDescription);
}

// q5
Console.WriteLine("\nRegion/Territories:");
var groupJoin = regionList.GroupJoin(territoryList,
                   r => r.RegionId,
                   t => t.RegionId,
                   (r, terGroup) => new
                   {
                       ters = terGroup,
                       regs = r.RegionDescription

                   });

foreach (var item in groupJoin)
{
    Console.WriteLine("--" + item.regs);
    foreach (var reg in item.ters)
    {
        Console.WriteLine("    -" + reg.TerritoryDescription);
    }
}

// q6
var order = new Order
{
    CustomerId = "FRANK",
    EmployeeId = 6,
    OrderDate = new DateTime(2022, 08, 02),
    ShipAddress = "7 Piccadilly Rd.",
    ShipCity = "New York",
    ShipCountry = "New York"
};

db.Orders.Add(order);
db.SaveChanges();

var order1 = new OrderDetail { OrderId = order.OrderId, ProductId = 11, UnitPrice = 95, Quantity = 3 };
var order2 = new OrderDetail { OrderId = order.OrderId, ProductId = 56, UnitPrice = 47, Quantity = 6 };
var order3 = new OrderDetail { OrderId = order.OrderId, ProductId = 74, UnitPrice = 120, Quantity = 5 };

db.OrderDetails.Add(order1);
db.OrderDetails.Add(order2);
db.OrderDetails.Add(order3);
db.SaveChanges();


// q7

// q8
db.Orders.Where(o=> o.OrderId==11083).



