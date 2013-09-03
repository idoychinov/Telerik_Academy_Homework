/* Problem 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
 */

using System;

class Palindromes
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        string[] words = text.Split(',', ' ', '.', '!', '?');
        foreach (string item in words)
        {
            Palindrome(item);
        }
    }
    private static void Palindrome(string s)
    {
        bool pal = false;
        for (int i = 0; i < s.Length/2; i++)
        {
            if (s[i] == s[s.Length - 1 - i])
            {
                pal = true;
            }
            else
            {
                pal = false;
                break;
            }
        }
        if (pal)
        {
            Console.WriteLine(s);
        }
    }
}

