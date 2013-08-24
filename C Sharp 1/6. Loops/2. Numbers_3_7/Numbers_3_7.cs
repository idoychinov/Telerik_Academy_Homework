/* Problem 2. Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class Numbers_3_7
{
    static void Main()
    {
        uint N;

        MyIOClass.Input(out N, "Enter the number N: ");
        for (int i = 1; i <= N; i++)
        {
            if (!((i % 3 == 0) && (i % 7 == 0)))
            {
                Console.WriteLine(i);
            }
        }


    }
}

