/* Problem 5. Write a method that calculates the number of workdays between today and given date, passed as parameter. 
 * Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
 */
using System;
using System.Linq;
using System.Globalization;



class NumberOfWorkdays
{
    static DateTime[] holidays = new DateTime[]
    {
        new DateTime(2013,9,6),
        new DateTime(2013,12,24),
        new DateTime(2013,12,25),
        new DateTime(2013,12,26),
        new DateTime(2013,12,31),
        new DateTime(2014,1,1),
        new DateTime(2014,3,3),
        new DateTime(2014,4,21),
        new DateTime(2014,5,1),
        new DateTime(2014,5,6),
        new DateTime(2014,9,22),
        new DateTime(2014,12,24),
        new DateTime(2014,12,25),
        new DateTime(2014,12,26),
        new DateTime(2014,12,31),
    };

    static void Main()
    {
        DateTime date;
        Console.Write("Enter date (greater than today's date) in ddmmyyyy format:");
        while (true)
        {
            if (DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date) && (DateTime.Compare(date, DateTime.Today) > 0))
            {
                break;
            }
            Console.Write("Incorect input please try again:");
        }

        Console.WriteLine("The number of workdays between {0} and {1} is {2}", DateTime.Today.Date.ToString("d"), date.Date.ToString("d"), CalculateWorkDays(date));
    }

    static int CalculateWorkDays(DateTime date)
    {

        DateTime today = DateTime.Today;
        int period = date.Subtract(today).Days + 1;
        int numberOfWeeks = period / 7;
        period = period - (numberOfWeeks * 2) - WeekendAdjustment(date) - HolidayAdjustment(date);
        return period;
    }



    static int WeekendAdjustment(DateTime date)
    {
        int weekendAdjusment = 0;
        if (date.DayOfWeek == DayOfWeek.Saturday)
        {
            weekendAdjusment += 1;
        }
        if (date.DayOfWeek == DayOfWeek.Sunday)
        {
            weekendAdjusment += 2;
        }
        if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
        {
            weekendAdjusment += 2;
        }
        if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
        {
            weekendAdjusment += 1;
        }
        return weekendAdjusment;
    }

    private static int HolidayAdjustment(DateTime date)
    {
        int days=0;
        foreach (DateTime item in holidays)
        {
            if ((DateTime.Compare(item,DateTime.Today) >= 0)&&(DateTime.Compare(item,date) <= 0))
            {
                days++;
            }
        }
        return days;
    }
}

