/* Problem 2. Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
*/

using System;

class MaxSumOf3x3
{
    static void Main()
    {
        int N, K, sum, maxSum,indX=0,indY=0;
        Console.Write("Enter N=");
        N = int.Parse(Console.ReadLine());
        Console.Write("Enter K=");
        K = int.Parse(Console.ReadLine());

        int[,] mat = new int[N, K];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                Console.Write("Matrix[{0},{1}]=", i, j);
                mat[i, j] = int.Parse(Console.ReadLine());
            }
        }
        sum = int.MinValue;
        maxSum = int.MinValue;

        for (int i = 0; i < N - 2; i++)
        {
            for (int j = 0; j < K - 2; j++)
            {
                sum = mat[i, j] + mat[i, j + 1] + mat[i, j + 2] + mat[i + 1, j] + mat[i + 1, j + 1] + mat[i + 1, j + 2] + mat[i + 2, j] + mat[i + 2, j + 1] + mat[i + 2, j + 2];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    indX = i;
                    indY = j;
                }
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                Console.Write("{0,4}", mat[i, j]); 
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n The max sum is: {0} and it starts at [{1},{2}]",maxSum,indX,indY);
    }
}

