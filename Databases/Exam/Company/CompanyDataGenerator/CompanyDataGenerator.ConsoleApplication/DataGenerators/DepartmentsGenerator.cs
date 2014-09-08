namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{

    using System;
    using System.Collections.Generic;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal class DepartmentsGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimumNameLength = 10;
        private const int MaximumNameLength = 50;

        public DepartmentsGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
            : base(db, randomGenerator, logger, amount)
        {
        }


        public override void Generate()
        {
            var departments = new HashSet<string>();

            while (departments.Count < this.Amount)
            {
                var name = this.RandomGenerator.GetRandomString(MinimumNameLength, MaximumNameLength);
                departments.Add(name);
            }

            var counter = 0;
            Logger.ProcessingMessage("Generating Departments");
            foreach (var name in departments)
            {
                this.Db.Departments.Add(new Department { Name = name });
                counter++;
                if (counter % DataGenerator.DataSaveStep == 0)
                {
                    Db.SaveChanges();
                    Logger.Progress(this.Amount, counter);
                }
            }

            Db.SaveChanges();
            Logger.Message("");
            Logger.SuccessMessage("Departments generated successfully");
        }
    }
}
