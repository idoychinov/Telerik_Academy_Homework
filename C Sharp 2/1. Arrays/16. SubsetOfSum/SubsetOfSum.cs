/* 16. * We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14  yes (1+2+5+6)
 */

using System;

class SubsetOfSum
{

    /// <summary>
    /// UNFINISHED
    /// </summary>
    static void Main()
    {
        Random rand = new Random();
        int[] arr = new int[rand.Next(1, 21)];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(1, 10);
            Console.Write(arr[i].ToString().PadLeft(2));
        }
        Console.WriteLine();


    }
}

