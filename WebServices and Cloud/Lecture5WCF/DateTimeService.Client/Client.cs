namespace DateTimeService.Client
{
    using System;
    using DateTimeService.Client.DateTimeServiceReference;

    public class Client
    {
        static void Main()
        {
            DateTimeServiceClient client = new DateTimeServiceClient();

            Console.WriteLine("Днес е {0}", client.GetDayOfWeek(DateTime.Now));
        }
    }
}
