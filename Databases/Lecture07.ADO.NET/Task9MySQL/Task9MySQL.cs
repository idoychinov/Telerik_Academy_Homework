namespace Task9MySQL
{
    using System;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Task 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI 
    /// administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). 
    /// Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    class Task9MySQL
    {
        static void Main()
        {
            // implement task 10 here?
            // please change those if your MySql server is with different settings
            const string server = "localhost";
            const string userID = "root";
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            string connectionStr = "Server=" + server + ";Uid=" + userID + ";Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {                
                Console.WriteLine("Connected to Server");

                var createDB = @" CREATE DATABASE IF NOT EXISTS BooksDB;
                                  USE test;
                                  CREATE TABLE IF NOT EXISTS Authors (
                                  id INT NOT NULL AUTO_INCREMENT,
                                  Name VARCHAR(100) NOT NULL,
                                  PRIMARY KEY (id),
                                  UNIQUE INDEX id_UNIQUE (id ASC))
                                  ENGINE = InnoDB;
                                  CREATE TABLE IF NOT EXISTS Books (
                                  id INT NOT NULL AUTO_INCREMENT,
                                  title VARCHAR(100) NOT NULL,
                                  publish_date DATE NULL,
                                  isbn VARCHAR(45) NULL,
                                  author_id INT NULL,
                                  PRIMARY KEY (id),
                                  UNIQUE INDEX id_UNIQUE (id ASC),
                                  UNIQUE INDEX title_UNIQUE (title ASC),
                                  UNIQUE INDEX Bookscol_UNIQUE (isbn ASC),
                                  INDEX FK_Books_Author_idx (author_id ASC),
                                  CONSTRAINT FK_Books_Author
                                  FOREIGN KEY (author_id)
                                  REFERENCES Authors (id)
                                  ON DELETE NO ACTION
                                  ON UPDATE NO ACTION)
                                  ENGINE = InnoDB";
                var command = new MySqlCommand(createDB,connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Database created if not existing");

                AddBook(connection);
                AddBook(connection);
                AddBook(connection);
                ListBooks(connection);
                FindBook(connection);
            }
        }
 
        // Sorry, no time to add all properties.
        private static void AddBook(MySqlConnection connection)
        {
            Console.WriteLine("Enter Book title");
            var title = Console.ReadLine();
            var addBook = "INSERT INTO Books (title) VALUES (@title)";
            var command = new MySqlCommand(addBook,connection);
            command.Parameters.AddWithValue("@title", title);
            command.ExecuteNonQuery();
            Console.WriteLine("Book added");
        }

        
        private static void FindBook(MySqlConnection connection)
        {
            Console.WriteLine("Enter book name to find");
            var searchPattern = Console.ReadLine();
            var searchBook = "SELECT * FROM Books WHERE title LIKE @searchPattern";
            var command = new MySqlCommand(searchBook,connection);
            command.Parameters.AddWithValue("@searchPattern", searchPattern);
            var reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Title: {0}", (string)reader["title"]);
                }
            }
        }
 
        private static void ListBooks(MySqlConnection connection)
        {
            Console.WriteLine("All Books");
            var selectAllBooks = "SELECT * FROM Books";
            var command = new MySqlCommand(selectAllBooks,connection);
            var reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Title: {0}", (string)reader["title"]);
                }
            }
        }
    }
}
