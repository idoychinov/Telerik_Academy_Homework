/* Problem 19. Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.
 */

using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        string emailPattern = @"\b\d{2}.\d{2}.\d{4}\b";
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        MatchCollection match = Regex.Matches(text, emailPattern);
        CultureInfo culture = new CultureInfo("en-CA");
        DateTime dt;
        foreach (Match item in match)
        {
            dt = DateTime.Parse(item.Value);
            Console.WriteLine(dt.ToString("DD:MM:YYYY",culture));
        }

    }
}

