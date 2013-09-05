/* 21. Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
 */

using System;
using MyIO;

class Combinations
{

    static void GenerateCombinations(int[] array, int index, int currentNumber, int lenght)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = currentNumber; i <= lenght; i++)
            {
                array[index] = i;
                GenerateCombinations(array, index + 1, i + 1, lenght);
            }
        }
    }


    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }


    static void Main()
    {
        int N, K;
        MyIOClass.Input(out N, "Enter N=");
        MyIOClass.Input(out K, "Enter K=");
        int[] combinations = new int[K];
        GenerateCombinations(combinations, 0, 1, N);
    }

}
