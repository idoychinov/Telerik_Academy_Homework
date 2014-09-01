namespace Task2Articles
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Task 2. A large trade company has millions of articles, each described by barcode, vendor, title and price.
    /// Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y]. Hint: use OrderedMultiDictionary<K,T> from 
    /// Wintellect's Power Collections for .NET. 
    /// </summary>
    public class Task2Articles
    {
        private const int Records = 1000000;
        private const int MinPrice = 1;
        private const int MaxPrice = 1000;
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            // String will simulate the class needed for article (barcode, vendor, title) since the order only needs to be by price
            var dictionary = new OrderedMultiDictionary<int, string>(true);

            Console.WriteLine("Start generating collection at {0:hh:mm:ss}", DateTime.Now);
            for (int i = 0; i < Records; i++)
            {
                var randomPrice = RandomGenerator.Next(MinPrice, MaxPrice + 1);
                dictionary.Add(randomPrice, "p" + 1);
            }

            Console.WriteLine("Start performing range search at {0:hh:mm:ss}", DateTime.Now);

            var rangeStart = RandomGenerator.Next(MinPrice, MaxPrice + 1);
            var rangeEnd = RandomGenerator.Next(MinPrice, MaxPrice + 1);

            if (rangeStart > rangeEnd)
            {
                var swap = rangeStart;
                rangeStart = rangeEnd;
                rangeEnd = swap;
            }

            var results = dictionary.Range(rangeStart, true, rangeEnd, true).Values.Count;

            Console.WriteLine("Searching done at {0:hh:mm:ss}\nFound {1} items in the price range [{2}..{3}]", DateTime.Now, results, rangeStart, rangeEnd);
        }
    }
}
