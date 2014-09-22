namespace StringContainsService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringContainsService
    {
        [OperationContract]
        int GetNumberOccurrences(string stringToSearchIn, string stringToFind);
    }
}