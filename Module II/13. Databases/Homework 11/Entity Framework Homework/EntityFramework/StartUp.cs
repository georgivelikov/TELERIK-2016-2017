using System;
using System.Linq;

namespace EntityFramework
{
    public class StartUp
    {
        public static void Main()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Task01(db);
                Task03(db);
                Task04(db);
                Task05(db, "SP", new DateTime(1997, 1, 1), new DateTime(1997, 12, 31));
            }   
        }

        private static void Task01(NorthwindEntities db)
        {
            Console.WriteLine("Task01:");
            var name = db.Customers.FirstOrDefault().ContactName;
            Console.WriteLine(name);
            Console.WriteLine(new string('-', 40));
        }

        private static void Task03(NorthwindEntities db)
        {
            Console.WriteLine("Task03:");
            var results =
                db.Orders.Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")
                    .Select(c => c.Customer)
                    .Distinct()
                    .ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"Customer company name: {result.CompanyName}");
            }

            Console.WriteLine(new string('-', 40));
        }

        private static void Task04(NorthwindEntities db)
        {
            Console.WriteLine("Task04:");
            var query = @"SELECT DISTINCT c.CompanyName FROM Customers c
                             JOIN Orders o
                               ON c.CustomerID = o.CustomerID
                            WHERE YEAR(o.ShippedDate) = 1997 AND o.ShipCountry = 'Canada'";

            var results = db.Database.SqlQuery<string>(query);

            foreach (var result in results)
            {
                Console.WriteLine($"Customer company name: {result}");
            }

            Console.WriteLine(new string('-', 40));
        }

        private static void Task05(NorthwindEntities db, string shipRegion, DateTime start, DateTime end)
        {
            Console.WriteLine("Task05:");
            var results = db.Orders
                .Where(o => o.ShipRegion == shipRegion && o.ShippedDate.Value >= start && o.ShippedDate.Value <= end);

            foreach (var result in results)
            {
                Console.WriteLine($"Order Date: {result.OrderDate}");
            }
        }
    }
}
