namespace Task6and7ReadExcel
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// Task 6. Create an Excel file with 2 columns: name and score:
    /// Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
    /// Task 7. Implement appending new rows to the Excel file.
    /// </summary>
    class Task6and7ReadExcel
    {
        static void Main()
        {
            OleDbConnection excelConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=..\..\Scores.xlsx; Extended Properties = Excel 12.0");
            excelConnection.Open();
            using (excelConnection)
            {
                Console.WriteLine("Table data:");
                ReadTable(excelConnection);

                Console.WriteLine("\nInsert data for Muncho \n");
                InseartToTable(excelConnection);

                Console.WriteLine("Table data after insert:");
                ReadTable(excelConnection);
            }
        }

        private static void ReadTable(OleDbConnection excelConnection)
        {
            var selectTable = @"SELECT * FROM [Sheet1$]";
            OleDbCommand command = new OleDbCommand(selectTable, excelConnection);
            OleDbDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Name: {0} -> Score: {1}", (string)reader["Name"], (double)reader["Score"]);
                }
            }
        }

        private static void InseartToTable(OleDbConnection excelConnection)
        {
            var insertInTable = @"INSERT INTO [Sheet1$] (Name, Score) VALUES (@name,@score)";
            OleDbCommand command = new OleDbCommand(insertInTable, excelConnection);
            command.Parameters.AddWithValue("@name", "Muncho");
            command.Parameters.AddWithValue("@score", 2);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }
    }
}
