/* Problem 14. A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
 * .NET – platform for applications from Microsoft
 * CLR – managed execution environment for .NET
 * namespace – hierarchical organization of classes
 */

using System;
using System.Collections.Generic;
using System.IO;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();
        word = word.Trim();
        string[,] dictionary;
        try
        {
            dictionary = ReadDictionary();
        }
        catch
        {
            Console.WriteLine("Error reading dictionary!");
            return;
        }

        FindInDictionary(dictionary, word);
    }

    private static void FindInDictionary(string[,] dictionary, string word)
    {
        for (int i = 0; i < dictionary.GetLength(0); i++)
        {
            if (string.Compare(dictionary[i, 0], word, true) == 0)
            {
                Console.WriteLine("\nWord: {0}\nExplanation: {1}",dictionary[i,0],dictionary[i,1]);
                return;
            }
        }
        Console.WriteLine("\nSorry, your word is not in the dictionary!");
    }

    private static string[,] ReadDictionary()
    {
        List<string> dictionary = new List<string>();
        try
        {
            StreamReader read = new StreamReader(@"..\..\dictionary.txt");
            using (read)
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    dictionary.Add(line);
                }
            }
        }
        catch
        {
            throw;
        }
        string[,] result = new string[dictionary.Count, 2];
        for (int i = 0; i < dictionary.Count; i++)
        {
            result[i, 0] = dictionary[i].Substring(0, dictionary[i].IndexOf(" "));
            result[i, 1] = dictionary[i].Substring(dictionary[i].IndexOf(" ")+3);
        }
        return result;
    }


}

