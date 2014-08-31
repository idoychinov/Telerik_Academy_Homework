namespace NorthWindTwin
{
    using System;
    using NorthwindApplication;

    class NorthWindTwin
    {        
        /// <summary>
        /// Task 6. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. 
        /// Find for the API for schema generation in MSDN or in Google.
        /// </summary>
        static void Main()
        {
            var newContext = new NorthwindEntities();
            newContext.Database.CreateIfNotExists();
            Console.WriteLine("NorthWindTwin successfully created");
        }
    }
}
