/* Problem 8. Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
*/

using System;

class IntBinaryRepresentation
{
    static void Main()
    {
        short number;
        Console.Write("Please enter number of type short:");
        while (!short.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Incorect Input, try again:");
        }
        string output = "";
        for (int i = 0; i < 16; i++)
        {
            output = (number & 1).ToString()+output;
            number = (short)(number >> 1);
        }
        Console.WriteLine("\nThe binary representation of the number is: {0}",output);
    }
}
