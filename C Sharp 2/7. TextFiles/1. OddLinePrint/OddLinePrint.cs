/* Problem 1. Write a program that reads a text file and prints on the console its odd lines.
 */
using System;
using System.IO;


class OddLinePrint
{
    static void Main()
    {
        StreamReader reader = null;
        try
        {
           reader = new StreamReader(@"..\..\file1.txt"); // file in the project folder
        }
        catch (Exception)
        {
            Console.WriteLine("Can't open file for reading!");
            return;
        }
        
        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                }
                line = reader.ReadLine();
            }
        }
    }
}
