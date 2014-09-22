namespace BugLogger.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugLogger.Models;

    public interface IBugLoggerContext
    {        
        IDbSet<Bug> Bugs { get; set; }

        int SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
