namespace Helpers
{
    using System;

    using Contracts;

    public class RandomGenerator : IRandomGenerator
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static IRandomGenerator randomGenerator;
        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static IRandomGenerator Instance
        {
            get
            {
                if (randomGenerator == null)
                {
                    randomGenerator = new RandomGenerator();
                }
                return randomGenerator;
            }
        }

        public int GetRandomNumber(int max)
        {
            return this.random.Next(max + 1);
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public char GetRandomCharacter(string posibleValues)
        {
            return posibleValues[this.random.Next(0, posibleValues.Length - 1)];
        }

        public string GetRandomString(int length)
        {
            var characters = new char[length];
            var lettersLength = letters.Length;

            for (int i = 0; i < length; i++)
            {
                characters[i] = letters[this.random.Next(0, lettersLength - 1)];
            }

            return new string(characters);
        }

        public string GetRandomString(int minLength, int maxLength)
        {
            var length = this.random.Next(minLength, maxLength);
            return GetRandomString(length);
        }

        public double GetRandomDouble(double min, double max)
        {
            return min + (max - min) * random.NextDouble();
        }

        public decimal GetRandomDecimal(decimal min, decimal max)
        {
            return (decimal)GetRandomDouble((double)min, (double)max);
        }

        public DateTime GetRandomDate(DateTime min, DateTime max)
        {
            var days = (max - min).Days;
            return min.AddDays(this.GetRandomNumber(days));
        }

        public DateTime GetRandomDateTime(DateTime min, DateTime max)
        {
            var date = GetRandomDate(min, max);
            date.AddSeconds(this.GetRandomDouble(0, 86400)); // 86400 seconds == 1 day
            return date;
        }
    }
}
