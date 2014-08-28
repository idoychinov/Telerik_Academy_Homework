namespace Task9MySqlAndTask10SqlLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SQLite;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Task 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI 
    /// administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). 
    /// Write methods for listing all books, finding a book by name and adding a book.
    /// 
    /// Task 10. Re-implement the previous task with SQLite embedded DB
    /// </summary>
    public class Task9MySqlAndTask10SqlLite
    {
        public static void Main()
        {
            DbConnection connection;
            DbCommand command;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please chose data provider.\nPress 1 for MySql or any other key for SQLite");
            Console.ForegroundColor = ConsoleColor.White;
            var key = Console.ReadKey().Key;
            Console.WriteLine();
            const string SqliteConnectonString = @"Data Source=:memory:;Version=3;New=True;";
            connection = new SQLiteConnection(SqliteConnectonString);
            command = new SQLiteCommand();
            string createDbString;
            switch (key)
            {
                case ConsoleKey.D1:
                    // please change those if your MySql server is with different settings
                    const string Server = "localhost";
                    const string UserID = "root";
                    Console.Write("Enter pass(default is empty, just press enter): ");
                    string pass = Console.ReadLine();
                    string connectionStr = "Server=" + Server + ";Uid=" + UserID + ";Pwd=" + pass + ";";

                    connection = new MySqlConnection(connectionStr);
                    command = new MySqlCommand();
                    createDbString = @"CREATE DATABASE IF NOT EXISTS BooksDB;
                                  USE BooksDB;
                                  CREATE TABLE IF NOT EXISTS Books (
                                  id INT NOT NULL AUTO_INCREMENT,
                                  title VARCHAR(100) NOT NULL,
                                  publish_date DATETIME NULL,
                                  isbn VARCHAR(45) NULL,
                                  author VARCHAR(100) NULL,
                                  PRIMARY KEY (id),
                                  UNIQUE INDEX id_UNIQUE (id ASC),
                                  UNIQUE INDEX title_UNIQUE (title ASC),
                                  UNIQUE INDEX Bookscol_UNIQUE (isbn ASC))
                                  ENGINE = InnoDB";
                    connection.Open();
                    Console.WriteLine("Connected to MySql Server");
                    break;
                default:
                    createDbString = @"CREATE TABLE IF NOT EXISTS Books (
                                  title VARCHAR(100) NOT NULL,
                                  publish_date DATETIME NULL,
                                  isbn VARCHAR(45) NULL,
                                  author VARCHAR(100) NULL,
                                  UNIQUE (title ASC),
                                  UNIQUE (isbn ASC))";
                    connection.Open();
                    Console.WriteLine("Connected to SQLite in memory Server");
                    break;
            }

            using (connection)
            using (command)
            {
                CreateDB(connection, command, createDbString);

                bool active = true;
                while (active)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Books Library Menu:");
                    Console.WriteLine("Press: 1 to Add book, 2 to List all books, 3 to search book, ESC to Exit.");
                    Console.ForegroundColor = ConsoleColor.White;
                    key = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            AddBook(connection, command);
                            break;
                        case ConsoleKey.D2:
                            ListBooks(connection, command);
                            break;
                        case ConsoleKey.D3:
                            FindBook(connection, command);
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

        // Using Abstract classes DbConnection and DbCommand so the methods can use any type of DBconnection
        private static void AddBook(DbConnection connection, DbCommand command)
        {
            Console.WriteLine("Enter Book title");
            var title = Console.ReadLine();
            Console.WriteLine("Enter Book Author");
            var author = Console.ReadLine();
            var isbn = Guid.NewGuid().ToString().Substring(0, 9);
            var addBook = "INSERT INTO Books (title,publish_date,isbn,author) VALUES (@title,@publishDate,@isbn,@author)";
            SetupCommand(
                command,
                connection,
                addBook,
                new Dictionary<string, object>() { { "@title", title }, { "@publishDate", DateTime.Now }, { "@isbn", isbn }, { "@author", author } });
            command.ExecuteNonQuery();
            Console.WriteLine("Book added");
        }

        private static void FindBook(DbConnection connection, DbCommand command)
        {
            Console.WriteLine("Enter book name to find");
            var searchPattern = Console.ReadLine();
            var searchBook = "SELECT * FROM Books WHERE title LIKE @searchPattern";
            SetupCommand(command, connection, searchBook, new Dictionary<string, object>() { { "@searchPattern", searchPattern } });
            ExecuteReader(command);
        }

        private static void ListBooks(DbConnection connection, DbCommand command)
        {
            Console.WriteLine("All Books");
            var selectAllBooks = "SELECT * FROM Books";
            SetupCommand(command, connection, selectAllBooks);
            ExecuteReader(command);
        }

        private static void SetupCommand(
            DbCommand command,
            DbConnection connection,
            string commandText,
            IDictionary<string, object> parameters = null)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.Parameters.Clear();
            if (parameters != null && parameters.Count > 0)
            {
                foreach (var item in parameters)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = item.Key;
                    parameter.Value = item.Value;
                    command.Parameters.Add(parameter);
                }
            }
        }

        private static void ExecuteReader(DbCommand command)
        {
            var reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var title = (string)reader["title"];
                    var publishDate = (reader["publish_date"] == DBNull.Value) ? "N/A" : ((DateTime)reader["publish_date"]).ToString();
                    var isbn = (reader["isbn"] == DBNull.Value) ? "N/A" : (string)reader["isbn"];
                    var authorId = (reader["author"] == DBNull.Value) ? "N/A" : (string)reader["author"];
                    Console.WriteLine("Title: {0}, Publish Date: {1}, ISBN: {2}, Author:{3}", title, publishDate, isbn, authorId);
                }
            }
        }

        private static void CreateDB(DbConnection connection, DbCommand command, string databaseInitializeString)
        {
            command.CommandText = databaseInitializeString;
            command.Connection = connection;
            command.ExecuteNonQuery();
            Console.WriteLine("Database created if not existing");
        }
    }
}
