namespace Task2ProductsCollection
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Task 2. Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b]. 
    /// Test for 500 000 products and 10 000 price searches. Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public class Task2ProductsCollection
    {
        private const int ProductsCount = 500000;
        private const int PriseSearches = 10000;
        private const int MinPrice = 1;
        private const int MaxPrice = 1000;
        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            Console.WriteLine("Start generating collection at {0:hh:mm:ss}", DateTime.Now);
            var collection = GenerateCollection();
            Console.WriteLine("Start performing searches at {0:hh:mm:ss}", DateTime.Now);
            PerformSearches(collection);
            Console.WriteLine("Searches done at {0:hh:mm:ss}", DateTime.Now);
        }

        private static OrderedBag<Product> GenerateCollection()
        {
            var collection = new OrderedBag<Product>();

            for (int i = 0; i < ProductsCount; i++)
            {
                var randomPrice = RandomGenerator.Next(MinPrice, MaxPrice + 1);
                collection.Add(new Product("p" + i, randomPrice));
            }

            return collection;
        }

        private static void PerformSearches(OrderedBag<Product> collection)
        {
            for (int i = 0; i < PriseSearches; i++)
            {
                var rangeStart = RandomGenerator.Next(MinPrice, MaxPrice + 1);
                var rangeEnd = RandomGenerator.Next(MinPrice, MaxPrice + 1);

                if (rangeStart > rangeEnd)
                {
                    var swap = rangeStart;
                    rangeStart = rangeEnd;
                    rangeEnd = swap;
                }

                var results = collection.Range(new Product("From", rangeStart), true, new Product("To", rangeEnd), true);

                // Only for verification that actual product ranges are returned.
                // Console.WriteLine("Search from {0} to {1} returned {2} results", rangeStart, rangeEnd, results.Count());
            }
        }
    }
}
