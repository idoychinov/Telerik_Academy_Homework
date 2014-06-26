namespace Task07FindOccurences
{
    using System;

    class Task07FindOccurences
    {
        static void Main()
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
