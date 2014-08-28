namespace Task1to5And8Northwind
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class Tasks1to5And8Northwind
    {
        // You must have Northwind database in your running SQL server. If its with another name please change this parameter.
        private const string NorthwindName = "[Northwind]";

        /// <summary>
        /// The first 5 tasks from the homework.
        /// </summary>
        public static void Main()
        {
            SqlConnection connectionExpress = new SqlConnection(
            "Server=.\\SQLEXPRESS; Database=TelerikAcademy; Integrated Security=true");
            SqlConnection connectionStandard = new SqlConnection(
            "Server=.; Database=TelerikAcademy; Integrated Security=true");
            Console.WriteLine("Trying to connect to SQLEXPRESS instance.");
            try
            {
                connectionExpress.Open();
                UseConnection(connectionExpress);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n\nTrying to connect to MSSQLSERVER instance.");
            try
            {
                connectionStandard.Open();
                UseConnection(connectionStandard);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Makes Northwind current DB and executes all the tasks sequentially.
        /// </summary>
        /// <param name="connection"></param>
        private static void UseConnection(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("USE " + NorthwindName, connection);
                command.ExecuteNonQuery();

                bool active = true;
                while (active)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Chose Task to Execute:");
                    Console.WriteLine("\nPress keys 1 / 2 / 3 / 4 / 5 / 8 to execute appropriate Task or press ESC to Exit.");
                    Console.ForegroundColor = ConsoleColor.White;
                    var key = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            CountCategories(connection);
                            break;
                        case ConsoleKey.D2:
                            SelectCategories(connection);
                            break;
                        case ConsoleKey.D3:
                            ProductCategories(connection);
                            break;
                        case ConsoleKey.D4:
                            AddProduct(connection);
                            break;
                        case ConsoleKey.D5:
                            GetImages(connection);
                            break;
                        case ConsoleKey.D8:
                            FindProducts(connection);
                            break;
                        case ConsoleKey.Escape:
                            active = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect command. Please try again.");
                            break;
                    }

                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Task 1. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
        /// </summary>
        /// <param name="connection"></param>
        private static void CountCategories(SqlConnection connection)
        {
            var sqlCountCategories = @"SELECT count(*) FROM Categories";
            SqlCommand command = new SqlCommand(sqlCountCategories, connection);
            int count = (int)command.ExecuteScalar();
            Console.WriteLine("Categories count {0}", count);
        }

        /// <summary>
        /// Task 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
        /// </summary>
        /// <param name="connection"></param>
        private static void SelectCategories(SqlConnection connection)
        {
            var sqlSelectCategories = @"SELECT CategoryName, Description FROM Categories";
            SqlCommand command = new SqlCommand(sqlSelectCategories, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Categories:");
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Name: {0}; Description: {1}", (string)reader["CategoryName"], (string)reader["Description"]);
                }
            }
        }

        /// <summary>
        /// Task 3. Write a program that retrieves from the Northwind database all product categories 
        /// and the names of the products in each category. Can you do this with a single SQL query (with table join)?
        /// </summary>
        /// <param name="connection"></param>
        private static void ProductCategories(SqlConnection connection)
        {
            var selectCategoriesWithProducts =
                @"SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p on c.CategoryID = p.CategoryID ORDER BY c.CategoryName";
            SqlCommand command = new SqlCommand(selectCategoriesWithProducts, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Categories:");
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("CategoryName: {0} -> ProductName: {1}", (string)reader["CategoryName"], (string)reader["ProductName"]);
                }
            }
        }

        /// <summary>
        /// Task 4. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
        /// </summary>
        /// <param name="connection"></param>
        private static void AddProduct(SqlConnection connection)
        {
            var insertProduct =
                @"INSERT INTO Products(ProductName, SupplierId, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock)" +
                " VALUES(@name, @supplier, @category, @quantity, @price, @stock)";
            SqlCommand command = new SqlCommand(insertProduct, connection);
            command.Parameters.AddWithValue("@name", "Potatoe!");
            command.Parameters.AddWithValue("@supplier", 1);
            command.Parameters.AddWithValue("@category", 1);
            command.Parameters.AddWithValue("@quantity", 1);
            command.Parameters.AddWithValue("@price", 100000);
            command.Parameters.AddWithValue("@stock", 2);
            command.ExecuteNonQuery();
            Console.WriteLine("Inserted New Product: Potatoe!");
        }

        /// <summary>
        /// Task 5. Write a program that retrieves the images for all categories in the 
        /// Northwind database and stores them as JPG files in the file system.
        /// <param name="connection"></param>
        private static void GetImages(SqlConnection connection)
        {
            var getImages =
                @"SELECT CategoryID, CategoryName, Picture FROM Categories";
            SqlCommand command = new SqlCommand(getImages, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine(@"Saving Images in \bin\debug folder :");
            using (reader)
            {
                while (reader.Read())
                {
                    var fileName = ((int)reader["CategoryID"]).ToString() + "." + (string)reader["CategoryName"] + ".jpg";
                    var imageData = (byte[])reader["Picture"];

                    // Skipping header data from the file saved in Northwind
                    using (MemoryStream ms = new MemoryStream(imageData, 78, imageData.Length - 78))
                    {
                        try
                        {
                            Image image = Image.FromStream(ms);
                            image.Save(fileName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Image saving failed: \n{0}", e.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Task 8. Write a program that reads a string from the console and finds all products that contain this string.
        /// Ensure you handle correctly characters like ', %, ", \ and _.
        /// <param name="connection"></param>
        /// </summary>
        private static void FindProducts(SqlConnection connection)
        {
            var sqlSelectCategories = @"SELECT ProductName FROM Products WHERE ProductName LIKE @searchPattern";
            SqlCommand command = new SqlCommand(sqlSelectCategories, connection);
            Console.WriteLine("Enter search pattern:");
            var searchString = Console.ReadLine();
            Console.WriteLine();
            command.Parameters.AddWithValue("@searchPattern", searchString);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Products:");
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Name: {0}", (string)reader["ProductName"]);
                }
            }
        }
    }
}
