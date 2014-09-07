namespace Helpers.Contracts
{
    using System;

    public interface IRandomGenerator
    {
        int GentRandomNumber(int min, int max);

        char GetRandomCharacter(string posibleValues);

        string GetRandomString(int minLength, int maxLenght);


    }
}
