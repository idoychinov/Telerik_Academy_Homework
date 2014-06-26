namespace Task04LongestSubSequence
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    class Task04LongestSubSequence
    {
        static List<int> LongestSubSequence(List<int> sequence)
        {
            List<int> resultSubSequence = new List<int>();
            int maxSequenceItem,currentSubSequenceLength,maxSubSequenceLength;

            if (sequence.Count != 0)
            {
                maxSequenceItem = sequence[0];
                currentSubSequenceLength = 1;
                maxSubSequenceLength = 1;
                for (int i = 1; i < sequence.Count - 1; i++)
                {
                    if (sequence[i] == sequence[i-1])
                    {
                        currentSubSequenceLength++;
                        if (currentSubSequenceLength > maxSubSequenceLength)
                        {
                            maxSequenceItem = sequence[i];
                            maxSubSequenceLength = currentSubSequenceLength;
                        }
                    }
                    else
                    {
                        currentSubSequenceLength = 1;
                    }
                }

                for (int i = 0; i < maxSubSequenceLength; i++)
                {
                    resultSubSequence.Add(maxSequenceItem);
                }
            }

            return resultSubSequence;
        }

        static void Main()
        {
            List<int> listToCheck = new List<int>()
            {
                1,3,6,3,7,2,2,4,5,1,0
            };

            Console.WriteLine("Expected result: [2,2]\nRecieved result: {0}\n", Utilities.ListToString(LongestSubSequence(listToCheck)));

            listToCheck = new List<int>()
            {
                1,1,1,3,7,2,2,2,5,1,0
            };

            Console.WriteLine("Expected result: [1,1,1]\nRecieved result: {0}\n", Utilities.ListToString(LongestSubSequence(listToCheck)));

            listToCheck = new List<int>()
            {
                1,2,3,4,8,4,5,2,1,3
            };

            Console.WriteLine("Expected result: [1]\nRecieved result: {0}\n", Utilities.ListToString(LongestSubSequence(listToCheck)));

        }
    }
}
