/* Problem 9. Write a program that deletes from given text file all odd lines. The result should be in the same file.
 */
using System;
using System.Collections.Generic;
using System.IO;



class DeleteOddLines
{
    static void Main()
    {
        List<string> evenLines = new List<string>();
        try
        {
            StreamReader read = new StreamReader(@"..\..\File.txt");
            using (read)
            {
                Console.WriteLine("Reading from file...");
                string line = read.ReadLine();
                bool even = false;
                while (line != null)
                {
                    if (even)
                    {
                        evenLines.Add(line);
                    }
                    even = !even;
                    line = read.ReadLine();
                }
            }
            Console.WriteLine("Reading complete!");
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
            return;
        }

        try
        {
            StreamWriter write = new StreamWriter(@"..\..\File.txt");
            Console.WriteLine("Writing even rows to file...");
            using (write)
            {
                for (int i = 0; i < evenLines.Count; i++)
                {
                    write.WriteLine(evenLines[i]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        Console.WriteLine("Writing complete!");
    }


}
