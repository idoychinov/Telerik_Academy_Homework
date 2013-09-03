/* Problem 14. Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
*/

using System;
using System.Collections.Generic;

class SetOfIntegers
{
    static int[] InputSequence()
    {
        List<int> seq = new List<int>();
        string current;
        int temp;
        Console.WriteLine("Please enter the sequence (type \"end\" to stop entering numbers):");
        while (true)
        {
            current = Console.ReadLine();
            if (current == "end")
            {
                if (seq.Count == 0)
                {
                    Console.WriteLine("The sequence can't be empty, write atlease one number!");
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (int.TryParse(current, out temp))
                {
                    seq.Add(temp);
                }
                else
                {
                    Console.WriteLine("Not a valid number, try again!");
                }
            }
        }
        return seq.ToArray();
    }



    static void Main()
    {
        int[] sequence = InputSequence();
        CalculateMinimum(sequence);
        CalculateMaximum(sequence);
        CalculateAvarage(sequence);
        CalculateSum(sequence);
        CalculateProduct(sequence);
    }


    private static void CalculateMaximum(int[] sequence)
    {
        int max=int.MinValue;
        foreach (int item in sequence)
        {
            if (item > max)
            {
                max = item;
            }
        }
        Console.WriteLine("The maximum number in the sequence is: {0}", max);
    }

    private static void CalculateMinimum(int[] sequence)
    {
        int min = int.MaxValue;
        foreach (int item in sequence)
        {
            if (item < min)
            {
                min = item;
            }
        }
        Console.WriteLine("The minimum number in the sequence is: {0}", min);
    }

    private static void CalculateAvarage(int[] sequence)
    {
        int total = 0, count = sequence.Length;
        foreach (int item in sequence)
        {
            total += item;
        }
        Console.WriteLine("The average in the sequence is: {0}", (decimal)total / count);
    }

    private static void CalculateSum(int[] sequence)
    {
        int sum = 0;
        foreach (int item in sequence)
        {
            sum += item;
        }
        Console.WriteLine("The sum of the numbers in the sequence is: {0}", sum);
    }

    private static void CalculateProduct(int[] sequence)
    {
        int prod = 1;
        foreach (int item in sequence)
        {
            prod *= item;
        }
        Console.WriteLine("The product of the numbers in the sequence is: {0}", prod);
    }

}

