namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Cars.Data.Migrations;
    using Cars.Data.Model;

    public class CarsContext : DbContext
    {
        private static string connectionName;


        public CarsContext()
            : base(CarsContext.connectionName ?? "CarsDb")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public CarsContext(string connectionName)
            : base(connectionName)
        {
           CarsContext.connectionName = connectionName;
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<Manufacturer> Manifacturers { get; set; }


        // Your context has been configured to use a 'CarsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Cars.Data.CarsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CarsModel' 
        // connection string in the application configuration file.
 
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}