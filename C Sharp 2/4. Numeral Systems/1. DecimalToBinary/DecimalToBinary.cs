/* Problem 1. Write a program to convert decimal numbers to their binary representation.
 */

using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        List<int> binary = new List<int>();
        int number;
        while (true)
        {
            Console.Write("Enter the number:");
            if (int.TryParse(Console.ReadLine(), out number)&& number>=0)
            {
                break;
            }
            Console.WriteLine("Incorect input try again!");
        }
        do
        {
            binary.Add(number % 2);
            number = number / 2;
        } while (number > 0) ;
        binary.Reverse();
        Console.Write("The decimal number in binary representation is: ");
        foreach (int item in binary)
	    {
		    Console.Write(item);
	    }
        Console.WriteLine();
    }
}
