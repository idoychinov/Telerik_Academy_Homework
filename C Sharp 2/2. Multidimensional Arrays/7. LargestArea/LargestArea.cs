/* Problem 7. * * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.
 * Hint: you can use the algorithm "Depth-first search" or "Breadth-first search" (find them in Wikipedia).
 */

using System;
using System.Collections.Generic;

/// <summary>
/// UNFINISHED
/// </summary>

class LargestArea
{
    static void Main()
    {
        Random rand = new Random();
        int N, K;
        Console.Write("Enter N=");
        N = int.Parse(Console.ReadLine());
        Console.Write("Enter K=");
        K = int.Parse(Console.ReadLine());
        int[,] mat = new int[N, K];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                mat[i, j] = rand.Next(1, 10);
                Console.Write("{0,4}", mat[i, j]);
            }
            Console.WriteLine();
        }

        bool[, ] visited = new bool[N, K];  
        bool[,] finalPath = new bool[N, K];
        int pathLength = 0;
        int currentPathLength = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                if (!visited[i, j])
                {
                    bool[,] currentPath = new bool[N, K];
                    currentPathLength = FindPath(mat, visited,currentPath, i, j);
                    if (currentPathLength > pathLength)
                    {
                        pathLength = currentPathLength;
                        finalPath = new bool[,](currentPath.Clone());
                    }
                }

            }
        }
        Console.WriteLine("The longest area of equal elements is:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                if (finalPath[i, j])
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write("{0,4}", mat[i, j]);
            }
            Console.WriteLine();
        }


    }

    private static int FindPath(int[,] mat, bool[,] visited,bool [,] currentPath, int i, int j) // add direction, depending on direction recursivly call find path until all paths are exausted
    {
        throw new NotImplementedException();
    }
}

