/* Problem 7. Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: 
 * Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class SelectionSort
{
    static void Main()
    {
        int N,min=0,temp;

        MyIOClass.Input(out N, "Enter N:");


        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Array[{0}]=", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            min = i;
            for (int j = i; j < N; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
        Console.WriteLine("The sorted array is:");
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
    }
}

