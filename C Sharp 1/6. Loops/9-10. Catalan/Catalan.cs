/* Problem 9-10. In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
 * Cn=(1/(n+1))(2n n)= (2n)!/((n+1)!*n!) for n >=0
 * Write a program to calculate the Nth Catalan number by given N.
 */
using System;
using MyIO; //using methods defined in another project within the solution.
using System.Numerics;

class Catalan
{
    static void Main()
    {
        uint N;
        decimal cat=1,temp;

        while (true)
        {
            MyIOClass.Input(out N, "Enter the number N: ");
            if (N > 0)
            {
                break;
            }
            Console.WriteLine("\nThe number N must be greater then 0");
        }

        // We are using the formula for recurrence relation ofCatalan numbers that states Cn-1=((2*(2n+1))/(n+2))*Cn
        for (int i = 1; i < N; i++)
        {
            temp = 2 * ((2 * i) + 1);
            cat*=(temp/(i+2));
        }


        Console.WriteLine("The Catalian number for N={0} is: {1:D:0}",N, cat);

    }
}

