/* 20. Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
 */

using System;
using MyIO;

class Variations
{

    static void GenerateVariations(int[] array, int index, int lenght)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 1; i <= lenght; i++)
            {
                array[index] = i;
                GenerateVariations(array, index + 1,lenght);
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
        int N,K;
        MyIOClass.Input(out N, "Enter N=");
        MyIOClass.Input(out K, "Enter K=");
        int[] variations = new int[K];
        GenerateVariations(variations, 0,N);
    }

}
