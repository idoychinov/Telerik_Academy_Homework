namespace CompanyDataGenerator.ConsoleApplication.DataGenerators
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal class EmployeeGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimumNameLength = 5;
        private const int MaximumNameLength = 20;
        private const decimal MinimumSalary = 50000;
        private const decimal MaximumSalary = 200000;
        private const int ProbabilityToHaveManager = 95;


        public EmployeeGenerator(CompanyEntities db, IRandomGenerator randomGenerator, ILogger logger, int amount)
            : base(db, randomGenerator, logger, amount)
        {
        }


        public override void Generate()
        {
             var employees = new HashSet<Employee>();
             var departmentIds = Db.Departments.Select(x=> x.Id).ToList();
             var numberOfDepartments = departmentIds.Count();

             Logger.ProcessingMessage("Generating Employees");
             for (int i = 0; i < this.Amount; i++)
             {
                 var employee = new Employee();
                 employee.FirstName = this.RandomGenerator.GetRandomString(MinimumNameLength, MaximumNameLength);
                 employee.LastName = this.RandomGenerator.GetRandomString(MinimumNameLength, MaximumNameLength);
                 employee.YearSalary = this.RandomGenerator.GetRandomDecimal(MinimumSalary, MaximumSalary);
                 employee.DepartmentId = departmentIds[this.RandomGenerator.GetRandomNumber(numberOfDepartments-1)];
                 this.Db.Employees.Add(employee);
                 if (i % DataGenerator.DataSaveStep == 0)
                 {
                     Db.SaveChanges();
                     Logger.Progress(this.Amount, i);
                 }
             }
             Db.SaveChanges();
             Logger.Progress(this.Amount, this.Amount);
             Logger.Message("");
             Logger.SuccessMessage("Employees generated successfully");

            Logger.ProcessingMessage("Adding Employees managers");

            var employeeIds = Db.Employees.Select(x => x.Id).ToList();
            var employeeIdsCount = employeeIds.Count;
            var count = 0;
            foreach (var employee in Db.Employees)
            {
                if (this.RandomGenerator.GetRandomNumber(1, 100) <= 95)
                {
                    employee.ManagerId = employeeIds[this.RandomGenerator.GetRandomNumber(0, employeeIdsCount - 1)];
                }
                count++;
                if (count % DataGenerator.DataSaveStep == 0)
                {
                    Db.SaveChanges();
                    Logger.Progress(this.Amount, count);
                }
            }
            Db.SaveChanges();
            Logger.Progress(this.Amount, this.Amount);
            Logger.Message("");
            Logger.SuccessMessage("Employees managers added successfully");
        }
    }
}
