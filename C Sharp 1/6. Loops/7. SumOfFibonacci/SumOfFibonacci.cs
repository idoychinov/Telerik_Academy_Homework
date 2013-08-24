/* Problem 7. Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 * Each member of the Fibonacci sequence (except the              first two) is a sum of the previous two members.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class SumOfFibonacci
{
    static void Main()
    {
        uint N;
        long memberA=0,memberB=1,temp,sum=0;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");           
            if (N > 1)
            {
                break;
            }
            Console.WriteLine("\nThe number N must be greater then 1. In case N is 0 or 1 the sum is 0");
        }

        for (int i = 1; i < N; i++)
        {
            sum += memberB;
            temp = memberA;
            memberA = memberB;
            memberB += temp;
        }
        

        Console.WriteLine("The sum S is: {0}", sum);

    }
}

