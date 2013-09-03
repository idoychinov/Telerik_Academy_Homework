/* Problem 5. You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
 */

using System;
using System.Text;

class ChangeToUpper
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        StringBuilder result= new StringBuilder();
        string openTag = "<upcase>", closeTag = "</upcase>";

        int indexStart = -1;
        int indexEnd=0;
        while ((indexStart = text.IndexOf(openTag, indexStart + 1, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            result.Append(text.Substring(indexEnd, indexStart - indexEnd));
            indexEnd = text.IndexOf(closeTag, indexStart + 1, StringComparison.OrdinalIgnoreCase);
            result.Append(text.Substring(indexStart + openTag.Length, indexEnd - indexStart-openTag.Length).ToUpper());
            indexEnd += closeTag.Length;
        }
        result.Append(text.Substring(indexEnd));
        Console.WriteLine("The resulting string is: {0}", result.ToString());
    }

}

