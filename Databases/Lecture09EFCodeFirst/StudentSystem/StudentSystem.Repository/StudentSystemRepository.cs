namespace StudentSystem.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using System.Linq.Expressions;
    using StudentSystem.Model;
    using StudentSystem.DataLayer;

    public class StudentSystemRepository<T> : IRepository<T> where T : class
    {
        private IStudentSystemDbContext context;

        public StudentSystemRepository(IStudentSystemDbContext studentSystemDbContext)
        {
            this.context = studentSystemDbContext;
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.All().Where(condition);
        }

        public void Add(T entity)
        {
            ChangeState(entity,EntityState.Added);
        }
        
        public void Update(T entity)
        {
            ChangeState(entity,EntityState.Modified);
        }
                
        public T Delete(T entity)
        {
            ChangeState(entity,EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            ChangeState(entity,EntityState.Detached);
        }

        
        private void ChangeState(T entity, EntityState state)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = state;
            this.context.SaveChanges();
        }
    }
}
