namespace NorthwindApplication.Tests
{
    using System;
    using System.Linq;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindApplication;

    [TestClass]
    public class NorthwindApplicationTests
    {
        NorthwindEntities db;
        TransactionScope transaction;

        [TestInitialize]
        public void Initialize()
        {
            db = new NorthwindEntities();
            // Using transaction scope to prevent actual changes in Database
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleenUp()
        {
            transaction.Dispose();
        }

        private Customer CreateTestCustomer()
        {
            var customer = new Customer();
            customer.CustomerID = "TSTCU";
            customer.CompanyName = "Test Company";
            customer.ContactTitle = "Test Title";
            customer.Address = "Test Address";
            return customer;
        }

        [TestMethod]
        public void InsertCustomerMethodAddsNewCustomerToDatabase()
        {
            var customer = CreateTestCustomer();

            var countBeforeInsert = CustomersDao.GetAllCustomers(this.db).Count();
            var insertedID = CustomersDao.InsertCustomer(customer, this.db);
            var countAfterInsert = CustomersDao.GetAllCustomers(this.db).Count();
            Assert.AreEqual(countBeforeInsert + 1, countAfterInsert, "Object not added to database");
            Assert.AreEqual("TSTCU", insertedID, "Added Object has different id");


        }

        [TestMethod]
        public void EditCustomerMakesCorrectChanges()
        {
            var customer = CreateTestCustomer();
            CustomersDao.InsertCustomer(customer, this.db);
            var editedCustomer = CreateTestCustomer();
            editedCustomer.CompanyName = "Edited Company";
            CustomersDao.EditCustomer("TSTCU", editedCustomer, this.db);
            var all = db.Customers.Select(x=> x.CustomerID).ToList();
            Assert.IsNotNull(this.db.Customers.Find("TSTCU"), "Edited object is missing from database");
            Assert.AreEqual("Edited Company", this.db.Customers.Find("TSTCU").CompanyName, "Edited object  name is not correct");
        }

        [TestMethod]
        public void DeleteCustomersDeletesAppropriate()
        {
            var customer = CreateTestCustomer();
            CustomersDao.InsertCustomer(customer, this.db);
            Assert.IsNotNull(this.db.Customers.Find("TSTCU"), "Object not added to Data base");
            CustomersDao.DeleteCustomer("TSTCU", this.db);
            Assert.IsNull(this.db.Customers.Find("TSTCU"), "Object not deleted from Data base");
        }
    }
}
