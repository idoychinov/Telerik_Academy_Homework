namespace EFPerformance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EFPerformanceModel;

    public class EFPerformance
    {
        public static void Main()
        {
            var context = new EFPerformanceModel();
            
            ConsoleMessage("Press any key to execute Task 1 N+1 implementation");
            Console.ReadKey();
            Console.WriteLine();
            Task1NplusOne(context);

            ConsoleMessage("\nPress any key to execute Task 1 Include implementation");
            Console.ReadKey();
            Console.WriteLine();
            Task1Include(context);

            ConsoleMessage("\nPress any key to execute Task 2 To List implementation");
            Console.ReadKey();
            Console.WriteLine();
            Task2ToList(context);

            ConsoleMessage("\nPress any key to execute Task 2 Optimized implementation");
            Console.ReadKey();
            Console.WriteLine();
            Task2Optimized(context);

            
        }

        private static void ConsoleMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Task 1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. 
        /// Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.
        /// </summary>
        public static void Task1NplusOne(EFPerformanceModel context)
        {
            // N+1 query implementation
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Employee - Name: {0}; Department: {1}; Town: {2}",
                  employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
        }

        public static void Task1Include(EFPerformanceModel context)
        {            
            // 1 query implementation
            foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("Employee - Name: {0}; Department: {1}; Town: {2}",
                  employee.FirstName + " " + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
            }
        }

        /// <summary>
        /// Task 2. Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), 
        /// then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". 
        /// Rewrite the same in more optimized way and compare the performance.
        /// </summary>
        /// <param name="context"></param>
        public static void Task2ToList(EFPerformanceModel context)
        {
            var towns = context.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia");
            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }
        }

        public static void Task2Optimized(EFPerformanceModel context)
        {
            var towns = context.Employees.Select(e => e.Address.Town.Name).Where(n => n == "Sofia").ToList();
            foreach (var town in towns)
            {
                Console.WriteLine(town);
            }
        }
    }
}
