using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BugLogger.Data.Repositories;
using BugLogger.Models;
using BugLogger.RestService.Controllers;

namespace BugLogger.RestService.Tests.Integration
{
     class TestBugsDependencyResolver<T> : IDependencyResolver where T : class
    {
        private IGenericRepository<T> repository;

        public IGenericRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(BugsController))
            {
                return new BugsController(this.Repository as IGenericRepository<Bug>);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
