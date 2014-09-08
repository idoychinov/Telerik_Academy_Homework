namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{

    using System;
    using System.Linq;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal class ProjectGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimumNameLength = 5;
        private const int MaximumNameLength = 50;


        public ProjectGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
            : base(db, randomGenerator, logger, amount)
        {
        }


        public override void Generate()
        {
            var counter = 0;
            Logger.ProcessingMessage("Generating Projects");
            for (var i = 0; i < this.Amount; i++)
            {
                this.Db.Projects.Add(new Project { Name = this.RandomGenerator.GetRandomString(MinimumNameLength, MaximumNameLength) });
                counter++;
                if (counter % DataGenerator.DataSaveStep == 0)
                {
                    Db.SaveChanges();
                    Logger.Progress(this.Amount, counter);
                }
            }
            
            Db.SaveChanges();
            Logger.Progress(this.Amount, this.Amount);
            Logger.Message("");
            Logger.SuccessMessage("Projects generated successfully");
        }

    }
}
