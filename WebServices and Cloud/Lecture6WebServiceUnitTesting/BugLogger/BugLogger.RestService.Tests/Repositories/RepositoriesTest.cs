using System;
using System.Linq;
using System.Transactions;
using BugLogger.Data;
using BugLogger.Data.Repositories;
using BugLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugLogger.RestService.Tests.Repositories
{

    [TestClass]
    public class RepositoriesTest
    {
        static TransactionScope transaction;

        [TestInitialize]
        public void TestInit()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void Find_WhenObjectIsInDb_ShouldReturnObject()
        {
            //arrange
            var bug = this.GetValidTestBug();

            var dbContext = new BugLoggerContext();
            var repository = new BugLoggerRepository<Bug>(dbContext);

            dbContext.Bugs.Add(bug);
            dbContext.SaveChanges();

            //act
            var bugInDb = repository.Find(bug.Id);

            //asesrt

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {
            //arrange -> prapare the objects
            var bug = GetValidTestBug();

            var dbContext = new BugLoggerContext();
            var repository = new BugLoggerRepository<Bug>(dbContext);

            //act -> test the objects

            repository.Add(bug);
            repository.SaveChanges();

            //assert -> validate the result

            var bugInDb = dbContext.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }
  
        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };
            return bug;
        }
    }
}
