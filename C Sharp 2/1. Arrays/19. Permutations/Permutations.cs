/* Problem 19. * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example: 
 * n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
 */
using System;
using MyIO;


class Permutations
{
    static void Main()
    {
        int N;
        MyIOClass.Input(out N, "Enter N=");
        int[] permutations = new int[N];
        GeneratePermutations(permutations);
    }

    static void GeneratePermutations(int[] array)
    {
        
            PrintArray(array);
        
    }


    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

