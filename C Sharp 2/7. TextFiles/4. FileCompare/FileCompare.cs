/* Problem 4. Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
 * Assume the files have equal number of lines.
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
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
            return;
        }
        string line;
        int same=0,different=0;
        using (reader1)
        {
            using (reader2)
            {
                line= reader1.ReadLine();
                while (line != null)
                {
                    if (line == reader2.ReadLine())
                    {
                        same++;
                    }
                    else
                    {
                        different++;
                    }
                    line = reader1.ReadLine();
                }
            }
        }
        Console.WriteLine("The files have {0} equal lines and {1} different lines",same,different);
        
    }
}
