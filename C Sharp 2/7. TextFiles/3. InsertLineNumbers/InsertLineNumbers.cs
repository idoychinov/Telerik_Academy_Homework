/* Problem 3. Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.
 */
using System;
using System.IO;


class InsertLineNumbers
{
    static void Main()
    {
        StreamReader reader = null;
        StreamWriter writer = null;
        try
        {
            reader = new StreamReader(@"..\..\file1.txt"); // file in the project folder
        }
        catch (Exception)
        {
            Console.WriteLine("Can't open file for reading!");
            return;
        }
        try
        {
            writer = new StreamWriter(@"..\..\file2.txt");
        }
        catch (Exception)
        {
            Console.WriteLine("Can't open file for writing!");
            return;
        }

        string line;

        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine(lineNumber.ToString()+": "+line);
                    line = reader.ReadLine();
                }
            }

        }

        Console.WriteLine("Added line numbers!");

    }
}
