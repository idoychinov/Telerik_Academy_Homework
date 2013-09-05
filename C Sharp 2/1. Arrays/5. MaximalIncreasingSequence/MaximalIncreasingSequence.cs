/* Problem 5. Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
 */

using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int element, sequence,maxSequence=1,maxSequenceElement=0;
        string seq;
        int[] arr= {1,4,3,2,6,7,4,4,7,3,1,78,4,23,6,7,8,10,2,1,3}; // You can change the array here
        
        
        element = arr[0];
        sequence = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (element < arr[i])// the only difference with the previous problem is that we we change the condition here so we seek increasing sequence
            {
                sequence++;
            }
            else
            {
                if (sequence > 1 && sequence>maxSequence)
                {
                    maxSequence = sequence;
                    maxSequenceElement = i-maxSequence;
                }
                sequence = 1;
            }
            element = arr[i];
        }

        if (maxSequence > 1)
        {
            Console.WriteLine("The longest sequence in this array:");
            foreach (byte elm in arr)
            {
                Console.Write("{0} ", elm);
            }
            seq = "{";
            for (int i = maxSequenceElement; i < maxSequenceElement + maxSequence; i++)
            {
                seq += arr[i];// we change the output here too in order to display the correct sequence
                if (i < maxSequenceElement + maxSequence - 1)
                {
                    seq += ",";
                }
            }
            seq += "}";
            Console.WriteLine("is {0}",seq);
        }
        else
        {
            Console.WriteLine("There is no sequence longer then 1 in this array:");
            foreach (byte elm in arr)
            {
                Console.Write("{0} ", elm);
            }
        }
    }
}
