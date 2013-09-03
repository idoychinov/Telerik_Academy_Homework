/* Problem 16. Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2004
 * Distance: 4 days
 */

using System;
using System.Globalization;


class ReadDates
{
    static void Main()
    {
        try
        {
            Console.Write("Please enter first date:");
            DateTime date1 = EnterDay(Console.ReadLine());
            Console.Write("Please enter the second date:");
            DateTime date2 = EnterDay(Console.ReadLine());
            Console.WriteLine("The number of days between the two dates is {0}",Math.Abs((date2-date1).Days));
        }
        catch(Exception e)
        {
            Console.WriteLine("Error: {0}",e.Message);
            return;
        }

    }

    private static DateTime EnterDay(string text)
    {
        DateTime date;
        
        try
        {
            date=DateTime.ParseExact(text,"d.MM.yyyy",CultureInfo.InvariantCulture);
        }
        catch
        {
            throw new FormatException("Incorect date format!");
        }
        return date;
    }
}

