namespace NorthwindApplication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Transactions;

    class NorthwindApplication
    {
        private static NorthwindEntities db;
        /// <summary>
        /// Task 1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
        /// Created via the designer in NorthwindDB.edmx
        /// </summary>
        public static void Main()
        {
            try
            {
                using (db = new NorthwindEntities())
                {
                    FindAllCustomersByCondition();
                    Console.WriteLine();
                    FindAllCustomersByConditionWithSql();
                    Console.WriteLine();
                    FindAllSales("BC", new DateTime(1997, 5, 1), new DateTime(1998, 4, 15));
                    ConcurrentChanges();
                    NewOrder();
                    CreateStoredProcedure();
                    UseStoredProcedure();
                }
            }
            catch (Exception e)
            {
                //Not the best approach but suppresses long exception messages in this homework.
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Task 2. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        private static void FindAllCustomersByCondition()
        {
            Console.WriteLine("Find Customers with orders from 1997 year shipped to Canada via LINQ");
            var result = (from customers in db.Customers
                          join orders in db.Orders on customers.CustomerID equals orders.CustomerID
                          where orders.ShippedDate.HasValue && orders.ShippedDate.Value.Year == 1997 &&
                          orders.ShipCountry == "Canada"
                          select customers.CompanyName).Distinct().ToList();
            PrintResults(result);

        }

        /// <summary>
        /// Task 3. Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        private static void FindAllCustomersByConditionWithSql()
        {
            Console.WriteLine("Find Customers with orders from 1997 year shipped to Canada via SQL Query");
            var query = "SELECT DISTINCT c.CompanyName FROM Customers c INNER JOIN Orders o on c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.ShippedDate) = 1997 AND o.ShipCountry = 'Canada'";
            var result = db.Database.SqlQuery<string>(query).ToList();
            PrintResults(result);

        }

        /// <summary>
        /// Task 5. Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        private static void FindAllSales(string region, DateTime startDate, DateTime endDate)
        {
            Console.WriteLine("Find all sales in region {0} in the period {1:dd.mm.yyyy} - {2:dd.mm.yyyy}", region, startDate.Date, endDate.Date);
            var result = (from orders in db.Orders
                          where orders.ShippedDate.HasValue && orders.ShippedDate.Value >= startDate &&
                          orders.ShippedDate.Value <= endDate && orders.ShipRegion == region
                          select orders.OrderID).ToList();
            PrintResults(result);

        }

        /// <summary>
        /// Task 7. Try to open two different data contexts and perform concurrent changes on the same records. 
        /// What will happen at SaveChanges()? How to deal with it?
        /// </summary>
        private static void ConcurrentChanges()
        {
            using (var dbSecondContext = new NorthwindEntities())
            {
                db.Regions.Find(1).RegionDescription = "Changed Region";
                dbSecondContext.Regions.Find(1).RegionDescription = "Changed from second context";
                // It works even that way but it's better to use one context
                dbSecondContext.SaveChanges();
                db.SaveChanges();
            }
        }

        // Task 8. By inheriting the Employee entity class create a class which allows employees to access their corresponding 
        // territories as property of type EntitySet<T>.
        // It's done automaticly as navigation property in EF 6. There is no EntitySet<T> in this version.

        /// <summary>
        /// Task 9. Create a method that places a new order in the Northwind database.
        /// The order should contain several order items. Use transaction to ensure the data consistency.
        /// </summary>
        private static void NewOrder()
        {
            using (var transaction = new TransactionScope())
            {
                // Add order
                var order = new Order()
                    {
                        CustomerID = db.Customers.First().CustomerID,
                        EmployeeID = db.Employees.First().EmployeeID,
                        OrderDate = DateTime.Now
                    };
                db.Orders.Add(order);
                //db.SaveChanges();
                // Add details
                var orderDetail1 = new Order_Detail()
                    {
                        OrderID = order.OrderID,
                        ProductID = db.Products.First().ProductID,
                        UnitPrice = 5,
                        Quantity = 2

                    };
                var orderDetail2 = new Order_Detail()
                    {
                        OrderID = order.OrderID,
                        ProductID = db.Products.Find(4).ProductID,
                        UnitPrice = 10.43m,
                        Quantity = 5

                    };
                db.Order_Details.AddRange(new[] { orderDetail1, orderDetail2 });
                db.SaveChanges();
                transaction.Complete();
                Console.WriteLine("Transaction completed successfully with ID {0}", order.OrderID);
            }
        }

        /// <summary>
        /// Task 10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier 
        /// name and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.
        /// </summary>
        private static void CreateStoredProcedure()
        {
            const string procedureCreateQuery =
                @"CREATE PROC [dbo].usp_TotalIncomeOfSupplier @name NVARCHAR(100), @period_start_date DATETIME, 
                @period_end_date DATETIME AS
                RETURN SELECT SUM(od.UnitPrice) as [Total Income]
                FROM Suppliers s JOIN Products p ON p.SupplierID = s.SupplierID
                JOIN [Order Details] od ON od.ProductID = p.ProductID JOIN Orders o ON o.OrderID = od.OrderID
                WHERE s.CompanyName = @name AND o.OrderDate BETWEEN @period_start_date AND @period_end_date";
            db.Database.ExecuteSqlCommand("USE Northwind");
            try
            {
                db.Database.ExecuteSqlCommand(procedureCreateQuery);
                Console.WriteLine("Procedure created successfully");
            }
            catch
            {
                Console.WriteLine("Procedure exists in database");
            }
        }

        /// <summary>
        /// Task 10 using the created stored procedure
        /// You need to update the model from databese before calling the procedure.
        /// </summary>
        private static void UseStoredProcedure()
        {
            var supplerName = "Tokyo Traders";
            var supplerIncome = db.usp_TotalIncomeOfSupplier(supplerName, new DateTime(1997, 1, 1), new DateTime(1998, 7, 1)).First();
            Console.WriteLine("Income of suppler {0} is {1}", supplerName, supplerIncome);
        }

        private static void PrintResults(IList resultSet)
        {
            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
