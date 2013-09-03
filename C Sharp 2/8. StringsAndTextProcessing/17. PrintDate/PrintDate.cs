/* Problem 17. Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with  * the day of week in Bulgarian.
 */

using System;
using System.Globalization;

class PrintDate
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter the date in format (day.month.year hour:minute:second):");
            DateTime date = EnterDay(Console.ReadLine());
            date=date.AddHours(6);
            date=date.AddMinutes(30);
            Console.WriteLine("The date after 6 hours and 30 minutes will be:\n{0:d.M.yyyy HH:m:s}", date);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: {0}", e.Message);
            return;
        }

    }

    private static DateTime EnterDay(string text)
    {
        DateTime date;

        try
        {
            date = DateTime.ParseExact(text, "d.M.yyyy HH:m:s", CultureInfo.InvariantCulture);
        }
        catch
        {
            throw new FormatException("Incorect date format!");
        }
        return date;
    }
}

