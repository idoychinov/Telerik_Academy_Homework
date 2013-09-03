/* Problem 18. Write a program for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
 */

using System;
using System.Text.RegularExpressions;

class ReplaceATags
{
    static void Main()
    {
        string emailPattern = @"\w+@\w+\.\w+";  
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        MatchCollection match = Regex.Matches(text, emailPattern);
        foreach (var item in match)
        {
            Console.WriteLine(item.ToString());
        }
        
    }
}

