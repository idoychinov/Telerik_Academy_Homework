/* Problem 23. Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
 */

using System;
using System.Text;

class WordCount
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        StringBuilder clearString = new StringBuilder();
        clearString.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != clearString[clearString.Length - 1])
            {
                clearString.Append(text[i]);
            }
        }

        Console.WriteLine("The cleared string without consecutive characters is:\n{0}",clearString.ToString());
     
    }

}

