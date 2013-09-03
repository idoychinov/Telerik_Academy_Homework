/* Problem 4. Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
using System;

class BinSearch
{
    static void Main()
    {
        int N, K,index;
        Console.Write("Enter the number N=");
        N = int.Parse(Console.ReadLine());
        Console.Write("Enter the number K=");
        K = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("array[{0}]=",i);
            arr[i]=int.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        Console.WriteLine("The sorted array is:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("{0,4}",arr[i]);
        }
        Console.WriteLine();
        index=Array.BinarySearch(arr, K);
        if (index >= 0)
        {
            Console.WriteLine("The largest number in the array that is <=K is {0} and is at position {1}", arr[index], index + 1);
        }
        else  // if the index is negative we can produse the index of the first element that has greater value then K by the following code (based on msdn description of Array.BinarySearch
        {
            index = ~index;
            if (index >= N)
            {
                index = N - 1;
            }
            else
            {
                index--;
            }
            Console.WriteLine("The largest number in the array that is <=K is {0} and is at position {1}", arr[index], index + 1);
        }
    }
}

