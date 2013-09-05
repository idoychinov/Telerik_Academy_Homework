/* Problem 4. Write a program that finds the maximal sequence of equal elements in an array.Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
 */

using System;

class MaxEqualElements
{
    static void Main()
    {
        byte element, sequence,maxSequence=1,maxSequenceElement=0;
        string seq;
        byte[] arr= {1,4,3,2,6,7,4,4,7,3,3,3,1,78,4,23,6,6,6,6,2,1,3}; // You can change the array here
        
        
        element = arr[0];
        sequence = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (element == arr[i])
            {
                sequence++;
            }
            else
            {
                if (sequence > 1 && sequence>maxSequence)
                {
                    maxSequence = sequence;
                    maxSequenceElement = element;
                }
                sequence = 1;
                element = arr[i];
            }
        }

        if (maxSequence > 1)
        {
            Console.WriteLine("The longest sequence in this array:");
            foreach (byte elm in arr)
            {
                Console.Write("{0} ", elm);
            }
            seq = "{";
            for (int i = 0; i < maxSequence; i++)
            {
                seq += maxSequenceElement;
                if(i<maxSequence-1)
                {
                    seq += ", ";
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
