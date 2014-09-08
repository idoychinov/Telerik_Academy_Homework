namespace CompanyDataGenerator.ConsoleApplication
{
    using System;

    using CompanyDataGenerator.DataLayer;
    using DataGenerators;
    using Helpers;
    using Helpers.Contracts;

    class CompanyDataGeneratorConsoleApp
    {
        private static readonly CompanyEntities db;
        private static readonly ILogger logger;
        private static readonly IRandomGenerator randomGenerator;

        static CompanyDataGeneratorConsoleApp()
        {
            logger = new ConsoleLogger();
            db = new CompanyEntities();
            randomGenerator = RandomGenerator.Instance;
            db.Configuration.AutoDetectChangesEnabled = false;
        }

        static void Main()
        {
            logger.MenuMessage(@"Current Connection setup-ed for SQL Server. For SQL Express change the connection string -> data source=.\SQLExpress . The connection string is in App.config in both ConsoleApplication and DataLayer projects.");

            var generators = new DataGeneratorsFactory().CreateDataGenerators(db, randomGenerator, logger);
            foreach(var generator in generators)
            {
                generator.Generate();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }

    }
}
