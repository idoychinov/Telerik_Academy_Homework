namespace ComputerBuildingSystem.Core
{
    using System;
    using ComputerBuildingSystem.Core.Interfaces;

    public class RandomProvider : IRandomProvider
    {
        private static IRandomProvider instance;

        private readonly Random randomGenerator;

        private RandomProvider()
        {
            this.randomGenerator = new Random();
        }

        public static IRandomProvider GetInstance()
        {
            // not a trade safe singleton but works for this task
            if (instance == null)
            {
                instance = new RandomProvider();
            }
            
            return instance;
        }

        public int GetRandomNumberInRange(int minNumber, int maxNumber)
        {
            if (minNumber >= maxNumber)
            {
                throw new ArgumentOutOfRangeException("Min value must be less then max value");
            }

            int randomNumber = this.randomGenerator.Next(minNumber, maxNumber + 1);
            return randomNumber;
        }
    }
}
