/* Problem 6. You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
 *		string = "43 68 9 23 318"  result = 461
 */
using System;
using System.Linq;

class SequenceSum
{
    static void Main()
    {
        Console.WriteLine("Enter sequence of positive integers separated by spaces:");
        string input = Console.ReadLine();
        Console.WriteLine("The sum of the integers is: {0}",CalculateSum(input));
    }

    private static int CalculateSum(string input)
    {
        string[] substrings = input.Split(' ');
        int sum=0;
        foreach (string item in substrings)
        {
            sum += int.Parse(item);
        }
        return sum;
    }
}

