/* Problem 22. Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.
 */

using System;
using System.Collections.Generic;

class WordCount
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        string[] words = text.Split(new char[] {' ',',','.','!','?'},StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> diction = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (diction.ContainsKey(word))
            {
                diction[word] = diction[word] + 1;
            }
            else
            {
                diction.Add(word, 1);
            }
        }

        Console.WriteLine("Occurence of words in string:");
        foreach (var word in diction)
        {
            string time = "time";
            if (word.Value > 1)
            {
                time = "times";
            }
            Console.WriteLine("{0,-40} {1} {2}",word.Key,word.Value,time);
        }
    }

}

