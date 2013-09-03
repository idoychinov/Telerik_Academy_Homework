/* Problem 2. Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 */
using System;

class EnterNumbers
{
    static void Main()
    {
        int min = 1, max = 100;
        int[] numbers = new int[10];
        try
        {
            for (int i = 0; i < 9; i++)
            {
                numbers[i] = ReadNumber(min, max);
                min = numbers[i];
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Error: {0}", err.Message);
        }
    }
    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter number:");
        int number = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
        }
        catch (FormatException err)
        {
            throw new FormatException("This is not a number!");
        }
        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException("The number should be greater than one, greater than the previous and less than 100!");
        }


        return number;
    }
}

