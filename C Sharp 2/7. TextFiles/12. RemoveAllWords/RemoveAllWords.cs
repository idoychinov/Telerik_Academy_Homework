/* Problem 12. Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.
 */
using System;
using System.Collections.Generic;
using System.IO;

class RemoveAllWords
{
    static void Main()
    {
        StreamReader read = null;
        string text="";
        List<string> wordList = new List<string>();
        try
        {
            read = new StreamReader(@"..\..\File.txt");
            Console.WriteLine("Reading from file...");
            text = read.ReadToEnd();
            Console.WriteLine("Reading complete!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        finally
        {
            
            if (read != null)
            {
                read.Dispose();
                
            }
        }
        
        try
        {
            read = new StreamReader(@"..\..\WordList.txt");
            Console.WriteLine("Reading from wordlist file...");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                wordList.Add(line);
            }
            Console.WriteLine("Reading complete!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        finally
        {
            if (read != null)
            {
                read.Dispose();
            }
        }

        foreach (string item in wordList)
        {
            text=text.Replace(item, "");
        }



        StreamWriter write = null;
        try
        {
            write = new StreamWriter(@"..\..\File.txt");
            Console.WriteLine("Writing to file...");
            write.Write(text);
            Console.WriteLine("Writing complte!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }
        finally
        {
            if (write != null)
            {
                write.Dispose();
            }
        }
    }
}
