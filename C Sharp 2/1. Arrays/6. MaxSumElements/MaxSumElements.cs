/* Problem 6. Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class MaxSumElements
{
    static void Main()
    {
        int N, K;

        MyIOClass.Input(out N, "Enter N:");
        MyIOClass.Input(out K, "Enter K:");
        if (K > N)
        {
            Console.WriteLine("K must be less or equal of N");
        }
        else
        {
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("Array[{0}]=", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort<int>(arr);
            Array.Reverse(arr);
            for (int i = 0; i < K; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }
    }
}

