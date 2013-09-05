/* 10. Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class SequenceOfSum
{
    static void Main()
    {
        int N;

        MyIOClass.Input(out N, "Enter N:");

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Array[{0}]=", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        int sumToCheck;
        MyIOClass.Input(out sumToCheck, "Enter Sum to check:");
        int checkSum = 0;
        int[] positionsArray = new int[arr.Length];
        int counter = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            checkSum = 0;
            for (int j = i; j < arr.Length; j++)
            {
                checkSum = checkSum + arr[j];
                if (checkSum == sumToCheck)
                {
                    positionsArray[i] = i + 1;
                    counter++;
                }
                else if (checkSum > sumToCheck)
                {
                    break;
                }
            }
        }

        Console.WriteLine("The subsequent elements which sum is equal to the requested sum ({0}) are: ", sumToCheck);
        int position = 0;
        int currentSum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            currentSum = 0;
            if (positionsArray[i] != 0)
            {
                Console.Write("{");
                position = positionsArray[i] - 1;
                for (int j = position; j < arr.Length; j++)
                {
                    currentSum = currentSum + arr[j];
                    if (currentSum <= sumToCheck)
                    {
                        Console.Write("{0}, ", arr[j]);
                    }
                    else if (currentSum > sumToCheck)
                    {
                        break;
                    }
                }
                Console.Write("\b\b}\n");
                
            }
        }
    }
}

