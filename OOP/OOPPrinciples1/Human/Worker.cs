using System;

namespace Human
{
    public class Worker : Human
    {
        public ushort WeekSalary { get; set; }
        public byte WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = (ushort)weekSalary;
            this.WorkHoursPerDay = (byte)workHoursPerDay;
        }

        public int MoneyPerHour()
        {
            int daySalary = (int)this.WeekSalary / 5;
            int hourSalary = daySalary / (int)this.WorkHoursPerDay;
            return hourSalary;
        }
    }
}
