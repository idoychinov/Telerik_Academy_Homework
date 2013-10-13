using System;
using System.Linq;

// Problem 6. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions.
// Rewrite the same with LINQ.

namespace P06.IntArray
{
    class IntArray
    {
        const int FIRST_DEVISOR = 3;
        const int SECOND_DEVISOR = 7;

        static int[] DevisableNumbersLambda(int[] initialArray, int firstDevisor, int secondDevisor)
        {
            int[] result;
            int devisor = firstDevisor * secondDevisor;
            result = initialArray.Where(x => x % devisor == 0 && x!=0).ToArray<int>();
            return result;
        }

        static int[] DevisableNumbersLINQ(int[] initialArray, int firstDevisor, int secondDevisor)
        {
            int[] result;
            int devisor = firstDevisor * secondDevisor;
            result =
                (from num in initialArray
                where num % devisor == 0 && num !=0
                select num).ToArray<int>();
            return result;
        }

        static void Main()
        {
            int[] initialArray = new int[100];
            for (int i = 0; i < initialArray.Length; i++)
            {
                initialArray[i] = i;    
            }

            // Lambda expressions implementation
            Console.WriteLine("Lambda expressions implementation");
            foreach (var number in DevisableNumbersLambda(initialArray,FIRST_DEVISOR,SECOND_DEVISOR))
            {
                Console.WriteLine(number);
            }

            //LINQ implementation
            Console.WriteLine("\n\nLINQ implementation");
            foreach (var number in DevisableNumbersLINQ(initialArray, FIRST_DEVISOR, SECOND_DEVISOR))
            {
                Console.WriteLine(number);
            }

        }
    }
}
