/* Problem 1. Describe the strings in C#. What is typical for the string data type? Describe the most important methods of the String class.
 */

using System;
using System.IO;

class DescribeString
{
    static void Main()
    {
        string text="";
        try
        {
            StreamReader r = new StreamReader(@"..\..\string_description.txt");
            using (r)
            {
                text = r.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
        }

        Console.WriteLine(text);
    }
}

