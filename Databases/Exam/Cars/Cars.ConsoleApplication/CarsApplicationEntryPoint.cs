namespace Cars.ConsoleApplication
{
    using System;

    using System.Linq;
    using Cars.Data;
    using Helpers;
    using Helpers.Contracts;

    public class CarsApplicationEntryPoint
    {
        private static string inputPath = @"..\..\..\Input";
        public static void Main()
        {
            var logger = new ConsoleLogger();

            
            string connectionName = ConnectionChoise(logger);
            if (connectionName == null)
            {
                logger.Message("Goodbye!");
                return;
            }
            var db = new CarsContext(connectionName);
            logger.ProcessingMessage("Connecting to Database");
            db.Cities.Count();
            logger.SuccessMessage("Connected to Database");

            logger.MenuMessage("Press any key to process input");
            Console.ReadKey();
            var jsonInputManager = new JsonInputManager(inputPath, db, logger);
            jsonInputManager.LoadData();
        }

        public static string ConnectionChoise(ILogger logger)
        {
            const string localDbConnectionName = "CarsDb";
            const string SqlServerConnectionName = "CarsDbSqlServer";
            const string SqlExpressConnectionName = "CarsDbSqlExpress";
            bool active = true;
            do
            {
                logger.MenuMessage("Select database type\nPress 1 for SQL Server\nPress 2 for SQL Express\nPress 3 for LocalDb");
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        return SqlServerConnectionName;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return SqlExpressConnectionName;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return localDbConnectionName;
                    case ConsoleKey.Escape:
                        return null;
                    default:
                        logger.ErrorMessage("Incorrect input. Please try again.");
                        break;
                }
            } while (active);
            return null;
        }
    }
}
