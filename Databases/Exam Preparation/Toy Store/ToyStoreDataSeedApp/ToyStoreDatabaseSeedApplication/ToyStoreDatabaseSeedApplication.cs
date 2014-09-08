namespace ToyStoreDatabaseSeedApplication
{
    using System;

    using Helpers;
    using Helpers.Contracts;

    public class ToyStoreDatabaseSeedApplication
    {

        private static ILogger logger;
        private static IInputManager input;
        private static IRandomGenerator random;


        public static void Main()
        {
            logger = new ConsoleLogger();
            input = new ConsoleInputManager();
            random = RandomGenerator.Instance;


            string connectionName = string.Empty; // Change to object DbContext or DbRepo
            if (connectionName == null)
            {
                logger.Message("Goodbye!");
                return;
            }

            // db.Configuration.AutoDetectChangesEnabled = false
            // random generation
            // db.Configuration.AutoDetectChangesEnabled = true

        }

        public static string ConnectionChoise()
        {
            const string localDbConnectionName = "ToyStore";
            const string SqlServerConnectionName = "ToyStoreSqlServer";
            const string SqlExpressConnectionName = "ToyStoreSqlExpress";
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
