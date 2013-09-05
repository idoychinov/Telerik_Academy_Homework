/* 9. Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
 */

using System;
using MyIO; //using methods defined in another project within the solution.

class FrequentNumber
{
    static void Main()
    {
        int N, number, frequency, temp;

        MyIOClass.Input(out N, "Enter N:");

        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Array[{0}]=", i);
            arr[i] = int.Parse(Console.ReadLine());
        }

        number = arr[0];
        frequency = 1;
        temp = 1;
        for (int i = 0; i < N; i++)
        {
            for (int j = i+1; j < N; j++)
            {
                if (arr[j] == arr[i])
                {
                    temp++;
                }
            }
            if (temp > frequency)
            {
                frequency = temp;
                number = arr[i];
            }
            temp = 1;
        }
        Console.WriteLine("The most frequent number is {0} ({1} times)",number,frequency);
    }
}

