namespace Lecture04.DictionariesHashTablesSets
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task1. Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    /// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    /// -2.5  2 times
    /// 3  4 times
    /// 4  3 times
    /// </summary>
    public class Task1CountArray
    {
        private static readonly double[] Array = new double[] { 4, -6.05, 3.4, 7.5, 2.5, 3.4, 4, 34 };

        public static void Main()
        {
            var occurrencess = new Dictionary<double, int>();

            foreach (var item in Array)
            {
                if (occurrencess.ContainsKey(item))
                {
                    occurrencess[item] += 1;
                }
                else
                {
                    occurrencess.Add(item, 1);
                }

                Console.Write(item + " ");
            }

            Console.WriteLine();

            foreach (var item in occurrencess)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
