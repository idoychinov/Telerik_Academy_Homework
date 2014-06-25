/* Problem 14. Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
 * Problem 15. * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).
*/

using System;
using System.Collections.Generic;

class SetOfNumbers
{

    static void Main()
    {
        CalculateMinimum(32.3, 124.1354, 5, -52, 1, -43, 1324.43512434);
        CalculateMaximum(32.3, 124.1354, 5, -52, 1, -43, 1324.43512434);
        CalculateAvarage(32.3, 124.1354, 5, -52, 1, -43, 1324.43512434);
        CalculateSum(32.3, 124.1354, 5, -52, 1, -43, 1324.43512434);
        CalculateProduct(32.3, 124.1354, 5, -52, 1, -43, 1324.43512434);
    }


    private static void CalculateMaximum<T>(params T[] sequence)
    {
        dynamic max = sequence[0];
        foreach (dynamic item in sequence)
        {
            if (item > max)
            {
                max = item;
            }
        }
        Console.WriteLine("The maximum number in the sequence is: {0}", max);
    }

    private static void CalculateMinimum<T>(params T[] sequence)
    {
        dynamic max = sequence[0];
        foreach (dynamic item in sequence)
        {
            if (item < max)
            {
                max = item;
            }
        }
        Console.WriteLine("The minimum number in the sequence is: {0}", max);
    }

    private static void CalculateAvarage<T>(params T[] sequence)
    {
        dynamic total = sequence[0];
        int count = sequence.Length;
        for (int i = 1; i < count; i++)
        {
            total += sequence[i];
        }
        Console.WriteLine("The average in the sequence is: {0}", (decimal)total / count);
    }

    private static void CalculateSum<T>(params T[] sequence)
    {
        dynamic sum = sequence[0]; ;
        for (int i = 1; i < sequence.Length; i++)
        {
            sum += sequence[i];
        }
        Console.WriteLine("The sum of the numbers in the sequence is: {0}", sum);
    }

    private static void CalculateProduct<T>(params T[] sequence)
    {
        dynamic prod = sequence[0];
        for (int i = 1; i < sequence.Length; i++)
        {
            prod *= sequence[i];
        }
        Console.WriteLine("The product of the numbers in the sequence is: {0}", prod);
    }

}

