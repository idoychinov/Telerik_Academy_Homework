/* Problem 3.Write a program that prints to the console which day of the week is today. Use System.DateTime.
 */
using System;
using System.Linq;


class DayOfWeek
{
    static void Main()
    {
        DateTime dayOfWeek;
        dayOfWeek = DateTime.Today;
        Console.WriteLine("Today is "+dayOfWeek.DayOfWeek);
    }
}

