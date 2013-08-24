/* Problem 3. Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class MinMax
{
    static void Main()
    {
        uint N;
        int min, max, current;

        MyIOClass.Input(out N, "Enter the number N: ");
        if ((N == 0) || (N == 1))
        {
            Console.WriteLine("N must be atleast 2");
        }
        else
        {
            MyIOClass.Input(out min, "Enter a number: ");
            max = min;
            for (int i = 1; i < N; i++)
            {
                MyIOClass.Input(out current, "Enter a number: ");
                if (current < min)
                {
                    min = current;
                }
                else if (current > max)
                {
                    max = current;
                }
            }
            Console.WriteLine("Minimal number is: {0}\nMaximal number is: {1}",min,max);
        }
    }
}

