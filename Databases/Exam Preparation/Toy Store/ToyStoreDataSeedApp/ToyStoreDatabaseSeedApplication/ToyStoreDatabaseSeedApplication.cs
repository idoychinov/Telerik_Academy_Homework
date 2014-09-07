namespace ToyStoreDatabaseSeedApplication
{
    using System;

    using Helpers;
    using Helpers.Contracts;

    public class ToyStoreDatabaseSeedApplication
    {

        private static ILogger logger;
        private static IInputManager input;

        public static void Main()
        {
            logger = new ConsoleLogger();
            input = new ConsoleInputManager();
            string connectionName = string.Empty; // Change to object DbContext or DbRepo
            if (!ConnectionChoise(connectionName))
            {
                logger.Message("Goodbye!");
                return;
            }


        }

        public static bool ConnectionChoise(string connectionName)
        {
            const string localDbConnectionName = "ToyStore";
            const string SqlServerConnectionName = "ToyStoreSqlServer";
            const string SqlExpressConnectionName = "ToyStoreSqlExpress";
            bool active = true;
            do
            {
                logger.MenuMessage("Select database type\nPress 1 for SQL Server\nPress 2 for SQL Express\nPress 3 for LocalDb");
                var menuChoise = input.MenuChoise();
                switch (menuChoise)
                {
                    case 1:
                        connectionName = SqlServerConnectionName;
                        return true;
                    case 2:
                        connectionName = SqlExpressConnectionName;
                        return true;
                    case 3:
                        connectionName = localDbConnectionName;
                        break;
                    case int.MaxValue:
                        return true;
                    default:
                        break;
                }
            } while (active);
            return false;
        }
    }
}
