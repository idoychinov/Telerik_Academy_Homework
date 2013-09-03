/* Problem 9. We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks. Example:
 * Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
 * Words: "PHP, CLR, Microsoft"
 * The expected result:
 * ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
 */

using System;

class ForbidenWords
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("Enter forbiden words (coma-separated):");
        string words = Console.ReadLine();
        string[] wordList = ExtractForbidenWords(words);
        foreach (string item in wordList)
        {
            text = ReplaceWords(text, item);
        }
        Console.WriteLine("The result is:\n{0}",text);
    }

    private static string[] ExtractForbidenWords(string words)
    {

        string[] split=words.Split(',');
        for (int i = 0; i < split.Length; i++)
        {
            split[i] = split[i].Trim();
        }
        return split;
    }

    private static string ReplaceWords(string text, string word)
    {
        string replace = new string('*', word.Length);
        return text.Replace(word, replace);
    }
}

