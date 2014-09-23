﻿namespace BugLogger.Data.Repositories
{
    using System;
    using System.Linq;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}