namespace Task07FindOccurences
{
    using System;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    /// 2  2 times
    /// 3  4 times
    /// 4  3 times
    /// </summary>
    public class Task07FindOccurences
    {
        public static void Main()
        {
            int[] array = new int[]
            {
                3, 4, 4, 2, 3, 3, 4, 3, 2
            };

            int[] occurenceMap = new int[1000];

            for (int i = 0; i < array.Length; i++)
            {
                occurenceMap[array[i]]++;
            }

            for (int i = 0; i < occurenceMap.Length; i++)
            {
                if (occurenceMap[i] > 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, occurenceMap[i]);
                }
            }
        }
    }
}
