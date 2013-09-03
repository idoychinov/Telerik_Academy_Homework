/* Problem 6. Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
 *	Ivan			George
 *	Peter			Ivan
 *	Maria			Maria
 *	George			Peter
 */
using System;
using System.Collections.Generic;
using System.IO;



class SortList
{
    static void Main()
    {
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(@"..\..\file1.txt"); 
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        string line;
        int lineCount=0;
        List<string> array = new List<string>();
        using (reader)
        {
            line = reader.ReadLine();
            while (line != null)
            {
                array.Add(line);
                lineCount++;
                line = reader.ReadLine();
            } 
        }

        array.Sort(string.Compare);

        try
        {
            StreamWriter writer = new StreamWriter(@"..\..\file2.txt");
            using (writer)
            {
                for (int i = 0; i < lineCount; i++)
                {
                    writer.WriteLine(array[i]);
                }
                Console.WriteLine("Writing to file successful!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }

    }

   
}
