/* Problem 1. Write a program that prints all the numbers from 1 to N.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class Numbers1ToN
{
    static void Main()
    {
        uint N;

        MyIOClass.Input(out N, "Enter the number N: ");
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(i);
        }
        

    }
}

