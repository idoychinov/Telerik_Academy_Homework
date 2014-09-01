namespace Task2ExtractStrings
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 2. Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:
    /// {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
    /// </summary>
    public class Task2ExtractStrings
    {
        private static readonly string[] Array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        public static void Main()
        {
            var occurrencess = new Dictionary<string, int>();

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
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
