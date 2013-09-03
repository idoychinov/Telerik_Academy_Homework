/* Problem 6. Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the   * result string into the console.
 */

using System;

class String20
{
    static void Main()
    {
        Console.WriteLine("Enter string (string length <=20 characters):");
        string text;
        while ((text = Console.ReadLine()).Length > 20)
        {
            Console.WriteLine("String too long. Please try again:");
        }
        string add = new string('*',20-text.Length);
        Console.WriteLine("The final string is: {0}",string.Concat(text,add));
    }
}

