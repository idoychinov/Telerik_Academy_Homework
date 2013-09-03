/* Problem 13. Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. The result should be written in the file  * result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.
 */
using System;
using System.Collections.Generic;
using System.IO;

class WordCount
{
    static void Main()
    {
        StreamReader read = null;
        string text = "";
        List<string> wordList = new List<string>();
        try
        {
            read = new StreamReader(@"..\..\words.txt");
            Console.WriteLine("Reading from words file...");
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

        try
        {
            read = new StreamReader(@"..\..\test.txt");
            Console.WriteLine("Reading from test file...");
            text= read.ReadToEnd();
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

        int[] count = new int[wordList.Count];
        string[] sorted;
        sorted= wordList.ToArray();

        try
        {
            count = CountWords(text, wordList);
            int[] key = new int[count.Length]; 
            count.CopyTo(key, 0);
            Array.Sort(key,sorted);
            Array.Reverse(sorted);
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
        }

        
        
        StreamWriter write = null;
        try
        {
            write = new StreamWriter(@"..\..\result.txt");
            Console.WriteLine("Writing to file...");
            for (int i = 0; i < count.Length; i++)
            {
                write.WriteLine(sorted[i]+" : "+count[Array.IndexOf(wordList.ToArray(),sorted[i])].ToString()+ " occurencess");                
            }
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

    private static int[] CountWords(string text, List<string> wordList)
    {
        int[] words = new int[wordList.Count];

        try
        {
            for (int i = 0; i < wordList.Count; i++)
            {
                int index = -1, count = 0;

                while ((index = text.IndexOf(wordList[i], index+1)) != -1)
                {
                    count++;
                }
                words[i] = count;
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        return words;
    }
}
