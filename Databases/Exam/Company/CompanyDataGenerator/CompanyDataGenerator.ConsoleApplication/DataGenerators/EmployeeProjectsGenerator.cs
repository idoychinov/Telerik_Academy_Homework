namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal class EmployeeProjectsGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimumEmployees = 2;
        private const int MaximumEmployees = 20;
        private const int averageEmployees = 5;
        private readonly DateTime StartDate = new DateTime(2000, 1, 1);
        private readonly DateTime EndDate = new DateTime(2020, 1, 1);


        public EmployeeProjectsGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
            : base(db, randomGenerator, logger, amount)
        {
        }

        public override void Generate()
        {
            var employeeIds = Db.Employees.Select(x => x.Id).ToList();
            var employeeIdsCount = employeeIds.Count;
            var projectIds = Db.Projects.Select(x => x.Id).ToList();
            var projectIdsCount = projectIds.Count;
            var randomUniqueNumbers = new Dictionary<int, int>();
            Logger.ProcessingMessage("Generating Employees in Projects");
            var totalNumberOfEmployes = 0;
            var counter = 0;
            for (int i = 0; i < projectIdsCount; i++)
            {
                var numberOfEmployees = this.RandomGenerator.GetRandomNumber(1, 4) == 1 ?
                    this.RandomGenerator.GetRandomNumber(5, 20) : this.RandomGenerator.GetRandomNumber(2, 4);
                totalNumberOfEmployes += numberOfEmployees;
                while (randomUniqueNumbers.Count() < numberOfEmployees)
                {
                    var employeeId = this.RandomGenerator.GetRandomNumber(0, employeeIdsCount - 1);
                    if(randomUniqueNumbers.ContainsKey(employeeIds[employeeId]))
                    {
                        continue;
                    }
                    randomUniqueNumbers.Add(employeeIds[employeeId], projectIds[i]);
                }

                foreach (var item in randomUniqueNumbers)
                {
                    var employeeProject = new EmployeesProject();
                    employeeProject.EmployeeId = item.Key;
                    employeeProject.ProjectId = item.Value;
                    var start = this.RandomGenerator.GetRandomDate(StartDate, DateTime.Now);
                    employeeProject.StartDate = start;
                    employeeProject.EndDate = this.RandomGenerator.GetRandomDate(start, EndDate);
                    Db.EmployeesProjects.Add(employeeProject);
                }
                randomUniqueNumbers.Clear();
                counter++;
                if (counter % DataGenerator.DataSaveStep == 0)
                {
                    Db.SaveChanges();
                    Logger.Progress(this.Amount, counter);
                }
            }

            Logger.Progress(projectIdsCount, projectIdsCount);

            Logger.ProcessingMessage(String.Format("\nTotal employees in projects {0} with average {1} employ per project", totalNumberOfEmployes, totalNumberOfEmployes / this.Amount));
            Db.SaveChanges();
            Logger.SuccessMessage("Employees in Projects generated successfully");
        }
    }
}
