/* Problem 12. Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class Matrix
{
    static void Main()
    {
        byte N;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");
            if ((N > 0)&&(N < 20))
            {
                break;
            }
            Console.WriteLine("\nThe number N must be greater then 0 and less then 20!\n");
        }
        for (int i = 1; i <= N; i++)
        {
            for (int j = i; j < N+i; j++)
            {
                Console.Write(j.ToString().PadRight(3,' '));
            }
            Console.WriteLine();
        }
    }
}

