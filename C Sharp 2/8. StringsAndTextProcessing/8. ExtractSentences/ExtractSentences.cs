/* Problem 8. Write a program that extracts from a given text all sentences containing given word.
 */

using System;

class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();
        string[] sentences = Extract(text);
        foreach (string item in sentences)
        {
            if (CheckSentance(item, word))
            {
                Console.WriteLine(string.Concat(item.Trim(), "."));
                //Console.WriteLine(item.Trim());
            }
        }
    }

    private static string[] Extract(string text)
    {
        return text.Split('.');
    }

    private static bool CheckSentance(string text, string word)
    {
        string[] words = text.Split(' ');
        if (Array.IndexOf(words, word) >= 0)
        {
            return true;
        }
        return false;
    }
}

