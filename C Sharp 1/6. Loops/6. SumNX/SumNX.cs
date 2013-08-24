/* Problem 6. Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN
 */
using System;
using MyIO; //using methods defined in another project within the solution.
using System.Numerics;

class SumNX
{
    static void Main()
    {
        uint N, X;
        BigInteger factorielN = 1, productX = 1, result=1;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");
            MyIOClass.Input(out X, "Enter the number X: ");
            if ((N > 0) && (X > 0))
            {
                break;
            }
            Console.WriteLine("\nThe numbers must be greater then 0");
        }

        for (int i = 1; i <= N; i++)
        {
            factorielN *= i;
            productX *= X;
            result += factorielN / productX;
        }
       

        Console.WriteLine("The sum S is: {0}", result);

    }
}

