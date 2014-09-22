namespace DateTimeService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDateTimeService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime value);
    }
}
