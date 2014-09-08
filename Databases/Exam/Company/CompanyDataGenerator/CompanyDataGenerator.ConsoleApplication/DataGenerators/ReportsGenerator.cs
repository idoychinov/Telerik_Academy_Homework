namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{

    using System;
    using System.Linq;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal class ReportGenerator : DataGenerator, IDataGenerator
    {
        private readonly DateTime StartDate = new DateTime(2000, 1, 1);
        private readonly DateTime EndDate = DateTime.Now;


        public ReportGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
            : base(db, randomGenerator, logger, amount)
        {
        }


        public override void Generate()
        {
            var counter = 0;
            Logger.ProcessingMessage("Generating Reports");
            var employeesIds = Db.Employees.Select(x=>x.Id).ToList();
            for (var i =0 ; i< employeesIds.Count; i++)
            {
                // add random number of reports per employee
                var numberOfReports = 50;

                for (int j = 0; j < numberOfReports; j++)
                {
                    this.Db.Reports.Add(new Report()
                    {
                        Time = this.RandomGenerator.GetRandomDateTime(StartDate, EndDate),
                        EmployeeId = employeesIds[i]
                    });
                    counter++;
                }
                if (counter % DataGenerator.DataSaveStep == 0)
                {
                    Db.SaveChanges();
                    Logger.Progress(this.Amount, counter);
                }
            }

            Db.SaveChanges();
            Logger.Progress(this.Amount, this.Amount);
            Logger.Message("");
            Logger.SuccessMessage("Reports generated successfully");
        }

    }
}
