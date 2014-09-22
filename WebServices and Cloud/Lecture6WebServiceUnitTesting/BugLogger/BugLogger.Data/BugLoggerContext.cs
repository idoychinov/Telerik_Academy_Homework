namespace BugLogger.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BugLogger.Data.Migrations;
    using BugLogger.Models;

    public class BugLoggerContext : DbContext, IBugLoggerContext
    {
        public BugLoggerContext()
            :base("DefautConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
