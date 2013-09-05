/* Problem 8. Write a program that finds the sequence of maximal sum in given array. Example:
 * {2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
 * Can you do it with only one loop (with single scan through the elements of the array)?
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class MaximalSumSequence
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

        int maxSum = 0;
        int currentSum = 0;
        int startIndex = 0;
        int endIndex = 1;
        for (int i = 0, j = 0; i < arr.Length; i++)
        {
            if (arr[j] <= 0)
                j++;
            else if (currentSum + arr[i] > maxSum)
            {
                currentSum += arr[i];
                maxSum = currentSum;
                startIndex = j;
                endIndex = i;
            }
            else if ((i < arr.Length - 1) && (arr[i] + arr[i + 1] > 0))
                currentSum += arr[i];
            else
            {
                currentSum = 0;
                i = j;
                j++;
            }
        }
        Console.WriteLine(maxSum);
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(arr[i] + " ");
        } 
    }
}

