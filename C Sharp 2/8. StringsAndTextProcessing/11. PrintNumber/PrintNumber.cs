/* Problem 11. Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.
 */

using System;

class ConvertStringToUCLiterals
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("As decimal number: {0,15:D}",number);
        Console.WriteLine("As hexadecimal number: {0,15:X}", number);
        Console.WriteLine("As percentage: {0,15:P}", number);
        Console.WriteLine("In scientific notation: {0,15:E}", number);
    }

}

