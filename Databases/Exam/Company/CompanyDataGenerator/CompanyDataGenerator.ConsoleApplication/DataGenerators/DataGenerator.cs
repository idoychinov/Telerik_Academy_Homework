namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{
    using System;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal abstract class DataGenerator : IDataGenerator
    {
        
        protected const int DataSaveStep = 100;

        protected ILogger Logger {get; set;}
        
        protected CompanyEntities Db {get; set;}
        
        protected IRandomGenerator RandomGenerator { get; set; }

        protected int Amount { get; set; }


        public DataGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
        {
            this.Db = db;
            this.RandomGenerator = randomGenerator;
            this.Logger = logger;
            this.Amount = amount;
        }

        public abstract void Generate();
    }
}
