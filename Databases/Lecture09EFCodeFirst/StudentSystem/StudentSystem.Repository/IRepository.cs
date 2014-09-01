namespace StudentSystem.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Search(Expression<Func<T, bool>> condition);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        void Detach(T entity);
    }
}
