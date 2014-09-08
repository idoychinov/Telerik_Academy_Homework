namespace CompanyDataGenerator.ConsoleApplication.Contracts
{
    using System.Collections.Generic;

    using CompanyDataGenerator.ConsoleApplication.DataGenerators;
    using CompanyDataGenerator.DataLayer;
    using Helpers.Contracts;

    internal interface IDataGeneratorFactory
    {
        IList<IDataGenerator> CreateDataGenerators(CompanyEntities db, IRandomGenerator random, ILogger logger);
    }
}
