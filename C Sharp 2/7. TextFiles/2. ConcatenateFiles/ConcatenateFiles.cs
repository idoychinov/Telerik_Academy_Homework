/* Problem 2. Write a program that concatenates two text files into another text file.
 */
using System;
using System.IO;


class ConcatenateFiles
{
    static void Main()
    {
        StreamReader reader1 = null;
        StreamReader reader2 = null;
        try
        {
            reader1 = new StreamReader(@"..\..\file1.txt"); // file in the project folder
            reader2 = new StreamReader(@"..\..\file2.txt"); // file in the project folder
        }
        catch (Exception)
        {
            Console.WriteLine("Can't open file for reading!");
            return;
        }
        string file1;
        using (reader1)
        {
            file1 = reader1.ReadToEnd();
        }
        string file2;
        using (reader2)
        {
            file2 = reader2.ReadToEnd();
        }

        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(@"..\..\file3.txt"); // file in the project folder
        }
        catch(Exception)
        {
            Console.WriteLine("Can't open file for writing!");
            return;
        }
        using (writer)
        {
            writer.Write(file1);
            writer.WriteLine();
            writer.Write(file2);
            Console.WriteLine("file3 created as concatination of file1.txt and file2.txt");
        }
    }
}
