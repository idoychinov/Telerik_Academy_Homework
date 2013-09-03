/* Problem 24. Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
 */

using System;
using System.Text;

class SortWords
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        string[] words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);
        foreach (string item in words)
        {
            Console.WriteLine(item);
        }
    }

}

