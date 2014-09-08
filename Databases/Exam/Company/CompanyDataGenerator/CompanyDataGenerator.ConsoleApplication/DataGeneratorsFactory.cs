namespace CompanyDataGenerator.ConsoleApplication
{
    using System;
    using System.Collections.Generic;

    using CompanyDataGenerator.ConsoleApplication.Contracts;
    using CompanyDataGenerator.ConsoleApplication.DataGenerators;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    class DataGeneratorsFactory : IDataGeneratorFactory
    {
        private const int NumberOfDepartments = 100;
        private const int NumberOfEmployees = 5000;
        private const int NumberOfProjects = 1000;
        private const int NumberOfReports = 250000;
        public IList<IDataGenerator> CreateDataGenerators(CompanyEntities db, IRandomGenerator random, ILogger logger)
        {
            var generators = new List<IDataGenerator>();
            generators.Add(new DepartmentsGenerator(db,random,logger,NumberOfDepartments));
            generators.Add(new EmployeeGenerator(db,random,logger,NumberOfEmployees));
            generators.Add(new ProjectGenerator(db,random,logger,NumberOfProjects));
            generators.Add(new EmployeeProjectsGenerator(db,random,logger,NumberOfProjects));
            generators.Add(new ReportGenerator(db,random,logger,NumberOfReports));         

            return generators;
        }
    }
}
