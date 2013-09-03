/* Problem 2. Write a program to convert binary numbers to their decimal representation.
 */

using System;
using System.Collections.Generic;

class BinaryToDecimal
{
    static void Main()
    {
        int[] binary;
        int number=0;
        string input;
        bool valid = true;
        while (true)
        {
            Console.Write("Enter the number in binary representation:");
            input = Console.ReadLine();
            foreach (char item in input)
            {
                if (item != '0' && item != '1')
                {
                    valid = false;
                }
            }
            if (valid)
            {
                binary = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    binary[input.Length-i-1] = (int)(input[i]-'0');
                }
                break;
            }
            Console.WriteLine("The entered number is not valid. Please try again.");
            valid = true;
        }

        for (int i = 0; i < binary.Length; i++)
        {
            number += binary[i] * (int)Math.Pow(2, i);
        }
        Console.WriteLine("The binary number in decimal representation is: {0}",number);
        Console.WriteLine();
    }
}
