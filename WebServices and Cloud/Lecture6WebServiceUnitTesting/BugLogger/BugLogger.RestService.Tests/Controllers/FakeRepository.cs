using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Data.Repositories;

namespace BugLogger.RestService.Tests.Controllers
{
    public class FakeRepository<T> : IGenericRepository<T> where T : class
    {
        public IList<T> Entities { get; set; }

        public void Add(T entity)
        {
            this.Entities.Add(entity);
        }

        public T Find(object id)
        {
            throw new NotImplementedException();
        }
        
        public IQueryable<T> All()
        {
            return this.Entities.AsQueryable();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        
        public T Delete(object id)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            this.IsSaveCalled = true;
            return 0;
        }
        
        public bool IsSaveCalled { get; set; }


    }
}
