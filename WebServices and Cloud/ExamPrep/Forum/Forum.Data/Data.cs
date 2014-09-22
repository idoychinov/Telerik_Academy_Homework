namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Forum.Models;
    using Forum.Data.Repositories;

    public abstract class Data
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories;

        public Data (DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        protected IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
