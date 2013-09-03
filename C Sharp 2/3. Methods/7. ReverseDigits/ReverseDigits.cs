/* Problem 7. Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
*/
using System;
using System.Globalization;
using System.Threading;

class Program
{
    static decimal ReverseDigits(decimal num)
    {
        string numToProcess = num.ToString();
        char[] arr = numToProcess.ToCharArray();
        Array.Reverse(arr);
        string processedNum = new string(arr);
        return decimal.Parse(processedNum);
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        decimal number;
        Console.Write("Enter decimal number:");
        number = decimal.Parse(Console.ReadLine());
        number=ReverseDigits(number);
        Console.WriteLine("The reversed number is {0}",number);
    }
}

