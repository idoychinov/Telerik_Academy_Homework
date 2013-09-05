/* 11. Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class BinarySearch
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

        Array.Sort<int>(arr);
        Console.WriteLine("The sorted array is:");
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        int first = 0, last = N, target, mid = mid = first / 2 + last / 2; ;
        bool found = false;
        MyIOClass.Input(out target, "The item we are searching for is:");
        Console.WriteLine();
        while (first <= last)
        {
            mid = first / 2 + last / 2;

            if (target < arr[mid])
            {
                last = mid - 1;
            }

            if (target > arr[mid])
            {
                first = mid + 1;
            }

            if (target == arr[mid])
            {
                found = true;
                break;
            }

        }
        if (found)
        {
            Console.WriteLine("Target " + target + " was found at index " + mid);
        }
        else
        {
            Console.WriteLine("Target was not found");
        }
    }
}
