using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Task11UsersAndGroups
{
    class Task11UsersAndGroups
    {
        /// <summary>
        /// Task 11. Create a database holding users and groups. Create a transactional EF based method that creates an user and
        /// puts it in a group "Admins". In case the group "Admins" do not exist, create the group in the same transaction.
        /// If some of the operations fail (e.g. the username already exist), cancel the entire transaction.
        /// </summary>
        static void Main()
        {
            // Please run the provided SQL script first in order to create the database in your server
            var db = new UsersAndGroupsDBEntities();
            using (db)
            using(var transaction = new TransactionScope())
            {
                //var adminGroup = (from groups in db.Groups where groups.Name = "Admins" select groups.GroupID)
                var adminGroup = db.Groups.Where(g => g.Name == "Admins").ToList();
                Group admin;
                if(adminGroup.Count == 0)
                {
                    admin = new Group() { Name = "Admins" };
                    db.Groups.Add(admin);
                }
                else
                {
                    admin = adminGroup.First();
                }
                var user = new User()
                {
                    UserName = "Pesho",
                    GroupID = admin.GroupID
                };
                db.Users.Add(user);
                try
                {
                    db.SaveChanges();
                    transaction.Complete();
                    Console.WriteLine("Transaction completed Successfully ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message +"\n"+e.InnerException);
                }
            }
        }
    }
}
