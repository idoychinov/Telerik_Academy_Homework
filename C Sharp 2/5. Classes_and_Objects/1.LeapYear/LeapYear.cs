/* Problem 1. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
 */

using System;
using System.Globalization;

class LeapYear
{

    static void Main()
    {
        string input;
        DateTime year;
        Console.Write("Enter yaer in yyyy format:");
        while (true)
        {
            input=Console.ReadLine();
            if (DateTime.TryParseExact(input,"yyyy",CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out year))
            {
                break;
            }
            Console.Write("Incorect input please try again:");
        }

        // cheating with already defined method :) otherwise the checks for leap year can be performed following http://en.wikipedia.org/wiki/Leap_year#Algorithm       
        if (DateTime.IsLeapYear(year.Year)) 
        { 
            Console.WriteLine("{0} is leap year",year.Year);
        }
        else
        {
            Console.WriteLine("{0} is not leap year",year.Year); 
        } 
        

    }
}

