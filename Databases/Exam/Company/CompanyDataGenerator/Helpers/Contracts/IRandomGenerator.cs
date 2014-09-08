namespace Helpers.Contracts
{
    using System;

    public interface IRandomGenerator
    {
        int GetRandomNumber(int max);

        int GetRandomNumber(int min, int max);

        char GetRandomCharacter(string posibleValues);

        string GetRandomString(int minLength, int maxLenght);
        
        double GetRandomDouble(double min, double max);
        
        decimal GetRandomDecimal(decimal min, decimal max);
        
        DateTime GetRandomDate(DateTime min, DateTime max);

        DateTime GetRandomDateTime(DateTime min, DateTime max);
        
    }
}
