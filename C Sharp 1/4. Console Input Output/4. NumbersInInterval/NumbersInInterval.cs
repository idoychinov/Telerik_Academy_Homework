/*Problem 4. Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
 */
using System;
using MyIO;

class NumbersInInterval
{
    static void Main()
    {
        int value1,value2,calc=0;
        MyIOClass.Input(out value1, "Please enter the first number: ");
        MyIOClass.Input(out value2, "Please enter the second number: ");
        calc = (Math.Max(value2, value1) / 5) - ((Math.Min(value2, value1)-1) / 5);
        Console.WriteLine("{0} numbers in the interval between {1} and {2} can be devided by 5 with remainder 0", calc, Math.Min(value1, value2), Math.Max(value1, value2));
    }
}

