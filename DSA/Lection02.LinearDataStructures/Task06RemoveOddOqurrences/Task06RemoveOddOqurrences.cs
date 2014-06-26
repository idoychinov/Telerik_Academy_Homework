namespace Task06RemoveOddOqurrences
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    class Task06RemoveOddOqurrences
    {
        // There are several better ways to do this with dictionary or hashset + array but i tried to find good solution using only List.
        static void Main()
        {
            List<int> sequence = new List<int>() 
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            };
            List<int> uniqueNumbers = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (uniqueNumbers.IndexOf(sequence[i]) < 0)
                {
                    uniqueNumbers.Add(sequence[i]);
                }
            }
            
            bool[] occurencesEvenTimes = new bool[uniqueNumbers.Count];
         
            for (int i = 0; i < sequence.Count; i++)
            {
                int index = uniqueNumbers.IndexOf(sequence[i]);
                occurencesEvenTimes[index] = !occurencesEvenTimes[index];
            }

            List<int> resultSequence = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                int index = uniqueNumbers.IndexOf(sequence[i]);
                if (!occurencesEvenTimes[index])
                {
                    resultSequence.Add(sequence[i]);
                }
            }

            Console.WriteLine("The resuilting sequence is {0}", Utilities.ListToString(resultSequence));

        }
    }
}
