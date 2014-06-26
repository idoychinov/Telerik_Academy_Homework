namespace Task08Majorant
{
    using System;
    using System.Collections.Generic;

    class Task08Majorant
    {   
        // Not the best posible solution since it would have been easier with hash set or dictionary, but i wanted to do it with the current material.
        static void Main()
        {
            int[] array = new int[]
            {
                2, 2, 3, 3, 2, 3, 4, 3, 3
            };
            List<int> uniqueNumbers = new List<int>();
            List<int> uniqueNumbersOccurences = new List<int>();


            for (int i = 0; i < array.Length; i++)
            {
                var index = uniqueNumbers.IndexOf(array[i]);
                if ( index < 0)
                {
                    uniqueNumbers.Add(array[i]);
                    uniqueNumbersOccurences.Add(1);
                }
                else
                {
                    uniqueNumbersOccurences[index]++;
                    if (uniqueNumbersOccurences[index] > array.Length / 2)
                {
                    Console.WriteLine("The majorant of the array is {0}", array[i]);
                }
                }

                
            }

        }
    }
}
