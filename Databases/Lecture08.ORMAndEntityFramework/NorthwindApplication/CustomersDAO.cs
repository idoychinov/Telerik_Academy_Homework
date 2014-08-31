namespace NorthwindApplication
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    /// <summary>
    /// Task 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. 
    /// Write a testing class.
    /// Customer Data Access Object class
    /// </summary>
    public class CustomersDao
    {
        public static IQueryable<Customer> GetAllCustomers(NorthwindEntities db)
        {
            return db.Customers;
        }

        public static string InsertCustomer(Customer customer, NorthwindEntities db)
        {
            var insertedCustomer = db.Customers.Add(customer);
            db.SaveChanges();
            return insertedCustomer.CustomerID;
        }

        public static void EditCustomer(string id, Customer editedCustomer, NorthwindEntities db)
        {
            ((IObjectContextAdapter)db).ObjectContext.ApplyCurrentValues("Customers", editedCustomer);
            db.SaveChanges();
        }

        public static void DeleteCustomer(string id, NorthwindEntities db)
        {
            var customer = db.Customers.Find(id);
            if(customer == null)
            {
                throw new ArgumentException("No item with ID={0} found in Database");
            }
            db.Customers.Remove(customer);
            db.SaveChanges();

        }
    }
}
