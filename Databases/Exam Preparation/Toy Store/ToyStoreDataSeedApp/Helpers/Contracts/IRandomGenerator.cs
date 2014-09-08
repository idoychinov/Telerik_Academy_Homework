namespace Helpers.Contracts
{
    using System;

    public interface IRandomGenerator
    {
        int GentRandomNumber(int max);

        int GentRandomNumber(int min, int max);

        char GetRandomCharacter(string posibleValues);

        string GetRandomString(int minLength, int maxLenght);
        
        double GetRandomDouble(double min, double max);
        
        decimal GetRandomDeciaml(decimal min, decimal max);
        
        DateTime GetRandomDate(DateTime min, DateTime max);

        DateTime GetRandomDateTime(DateTime min, DateTime max);
        
    }
}
