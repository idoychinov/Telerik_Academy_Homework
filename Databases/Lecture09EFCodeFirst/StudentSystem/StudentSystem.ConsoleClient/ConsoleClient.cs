namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using StudentSystem.Model;
    using StudentSystem.Repository;
    using StudentSystem.DataLayer;

    class ConsoleClient
    {
        const ConsoleColor consoleMenuColor = ConsoleColor.Cyan;
        const ConsoleColor consoleErrorColor = ConsoleColor.Red;
        const ConsoleColor consoleSuccessColor = ConsoleColor.Green;
        const ConsoleColor consoleDefaultColor = ConsoleColor.White;

        /// <summary>
        /// Task 1. Using c0de first approach, create database for student system with the following tables:
        /// Students (with Id, Name, Number, etc.)
        /// Courses (Name, Description, Materials, etc.)
        /// StudentsInCourses (many-to-many relationship)
        /// Homework (one-to-many relationship with students and courses), fields: Content, TimeSent
        /// Annotate the data models with the appropriate attributes and enable code first migrations
        /// Task 2. Write a console application that uses the data
        /// Task 3. Seed the data with random values
        /// </summary>
        static void Main()
        {

            // Migration strategy
            using (var db = InitializeConnection())
            {
                var studentsDb = new StudentSystemRepository<Student>(db);
                var coursesDb = new StudentSystemRepository<Course>(db);
                var homeworkDb = new StudentSystemRepository<Homework>(db);

                var active = true;

                do
                {
                    ConsoleMenuMessage("Main menu:");
                    ConsoleMenuMessage("Students: 1 for Add; 2 for Edit; 3 for Delete");
                    // Same can be implemented for the other tables with slight modifiactions.
                    ConsoleMenuMessage("0 to view all records; ESC to exit");
                    var key = Console.ReadKey();
                    Console.WriteLine();
                    try
                    {
                        int id;
                        string name, number;
                        switch (key.Key)
                        {
                            case ConsoleKey.NumPad1:
                            case ConsoleKey.D1:
                                ConsoleMenuMessage("Add Student:");
                                Console.Write("Name:");
                                name = Console.ReadLine();
                                Console.Write("Number (exactly 8 symbols):");
                                number = Console.ReadLine();
                                studentsDb.Add(new Student { Name = name, Number = number });
                                Console.WriteLine("Student added");
                                break;
                            case ConsoleKey.NumPad2:
                            case ConsoleKey.D2:
                                ConsoleMenuMessage("Edit Student:");
                                Console.Write("ID:");
                                id = int.Parse(Console.ReadLine());
                                var student = studentsDb.Search(s => s.Id == id).First();
                                Console.Write("Name:");
                                student.Name = Console.ReadLine();
                                Console.Write("Number (exactly 8 symbols):");
                                student.Number = Console.ReadLine();
                                studentsDb.Update(student);
                                Console.WriteLine("Student edited");
                                break;
                            case ConsoleKey.NumPad3:
                            case ConsoleKey.D3:
                                ConsoleMenuMessage("Delete Student:");
                                Console.Write("ID:");
                                id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Student {0} deleted", studentsDb.Delete(studentsDb.Search(s => s.Id == id).First()).ToString());
                                break;
                            case ConsoleKey.NumPad0:
                            case ConsoleKey.D0:
                                ConsoleMenuMessage("All Students:");

                                foreach (var item in studentsDb.All().ToList())
                                {
                                    Console.WriteLine("Student {0}", item.ToString());
                                }
                                break;
                            case ConsoleKey.Escape:
                                active = false;
                                break;
                            default:
                                ConsoleErrorMessage("Incorrect input please try again.");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleErrorMessage(string.Format("Error occurred while trying to work with database: {0}\nPlease try again.", e.Message));
                    }
                }
                while (active);
            }

        }

        private static StudentsSystemDbContext InitializeConnection()
        {
            // The connection timeout is set in the connection string to 15 seconds for SQL and SQL express servers. {Connection Timeout=15}
            const string sqlConnectionName = "StudentSystemSQLServer";
            const string sqlExpressConnectionName = "StudentSystemSQLExpress";
            var incorectInput = true;

            StudentsSystemDbContext context;
            do
            {
                // If using localdb currently is not working. Need to refactor the code.
                ConsoleMenuMessage("Please chose the database server type you have installed on your computer");
                ConsoleMenuMessage("1 for SQL Server; 2 for SQLEXPRESS; 3 for using LocalDB from Visual Studio");
                var key = Console.ReadKey();
                Console.WriteLine("\nTrying to connect to chosen database server...");
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            context = new StudentsSystemDbContext(sqlConnectionName);
                            context.Students.ToList();
                            ConsoleSuccessMessage("Successfully connected to SQL Server");
                            return context;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            context = new StudentsSystemDbContext(sqlExpressConnectionName);
                            context.Students.ToList();
                            ConsoleSuccessMessage("Successfully connected to SQLEXPRESS Server");
                            return context;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            context = new StudentsSystemDbContext();
                            context.Students.ToList();
                            ConsoleSuccessMessage("Successfully connected to LocalDB Server");
                            return context;
                        default:
                            ConsoleErrorMessage("Incorrect input please try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    ConsoleErrorMessage(string.Format("Error occurred while trying to connect to database: {0}\nPlease try again.", e.Message));
                }
            }
            while (incorectInput);
            throw new InvalidOperationException("Connection could not be initialized");
        }

        private static void ConsoleMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = consoleDefaultColor;
        }

        private static void ConsoleMenuMessage(string message)
        {
            ConsoleMessage(message, consoleMenuColor);
        }

        private static void ConsoleErrorMessage(string message)
        {
            ConsoleMessage(message, consoleErrorColor);
        }

        private static void ConsoleSuccessMessage(string message)
        {
            ConsoleMessage(message, consoleSuccessColor);
        }
    }
}
