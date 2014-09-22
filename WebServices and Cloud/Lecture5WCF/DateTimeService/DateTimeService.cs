namespace DateTimeService
{
    using System;
    using System.Collections.Generic;

    public class DateTimeService : IDateTimeService
    {
        private readonly IDictionary<DayOfWeek, string> dayOfWeekInBg = new Dictionary<DayOfWeek, string>()
        {
            {DayOfWeek.Monday, "Понеделник"},
            {DayOfWeek.Tuesday, "Вторник"},
            {DayOfWeek.Wednesday, "Сряда"},
            {DayOfWeek.Thursday, "Четвъртък"},
            {DayOfWeek.Friday, "Петък"},
            {DayOfWeek.Saturday, "Събота"},
            {DayOfWeek.Sunday, "Неделя"},
        };

        public string GetDayOfWeek(DateTime date)
        {
            return dayOfWeekInBg[date.DayOfWeek];
        }
    }
}
