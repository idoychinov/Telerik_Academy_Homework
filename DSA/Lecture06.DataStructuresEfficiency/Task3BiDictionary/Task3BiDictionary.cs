namespace Task3BigDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 3. Implement a class BiDictionary<K1,K2,T> that allows adding triples {key1, key2, value} and fast search by key1, key2 or by both key1 and key2.
    /// Note: multiple values can be stored for given key.
    /// </summary>
    public class Task3BiDictionary
    {
        public static void Main()
        {
            var bidictionary = new BiDictionary<int, double, string>();

            bidictionary.Add(4, 0.5, "first");
            bidictionary.Add(3, 1.3, "second");
            bidictionary.Add(-4, 0.5, "third");
            bidictionary.Add(12, -0.6, "fourth");
            bidictionary.Add(3, -0.6, "fifth");
            bidictionary.Add(3, 1.3, "sixth");
            bidictionary.Add(11, 5, "seventh");
            Console.WriteLine("Search for items with first key 3: ");
            PrintCollection(bidictionary.Search(3));

            Console.WriteLine("\nSearch for items with second key -0.6: ");
            PrintCollection(bidictionary.Search(-0.6));

            Console.WriteLine("\nSearch for items with first key 3 and second key 1.3: ");
            PrintCollection(bidictionary.Search(3, 1.3));
        }

        private static void PrintCollection(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
