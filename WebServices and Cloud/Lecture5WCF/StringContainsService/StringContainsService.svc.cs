namespace StringContainsService 
{
    using System;

    public class StringContainsService : IStringContainsService
    {
        public int GetNumberOccurrences(string stringToSearchIn, string stringToFind)
        {
            var count = 0;
            var currentIndex = stringToSearchIn.IndexOf(stringToFind,0);

            while(currentIndex>-1)
            {
                count++;
                if(currentIndex== stringToSearchIn.Length-1)
                {
                    break;
                }
                currentIndex = stringToSearchIn.IndexOf(stringToFind,currentIndex+1);
            }

            return count;
        }
    }
}
