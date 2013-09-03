/* Problem 4. Write a program to convert hexadecimal numbers to their decimal representation.
 */

using System;
using System.Collections.Generic;

class HexadecimalToDecimal
{
    static void Main()
    {
        int[] hexadecimal;
        int number = 0,temp=0;
        string input;
        bool valid = true;
        while (true)
        {
            Console.Write("Enter the number in hexadecimal representation:");
            input = Console.ReadLine();
            foreach (char item in input)
            {
                if ((item < '0' || item > '9') && (item < 'a' || item > 'f') && (item < 'A' || item > 'F'))
                {
                    valid = false;
                }
                
            }
            if (valid)
            {
                hexadecimal = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] >= 'a' && input[i] <= 'f')
                    {
                        temp = input[i] - 'W';
                    }
                    else if (input[i] >= 'A' && input[i] <= 'F')
                    {
                        temp = input[i] - '7';
                    }
                    else
                    {
                        temp=input[i] - '0';
                    }
                    hexadecimal[input.Length - i - 1] = (int)(temp);
                }
                break;
            }
            Console.WriteLine("The entered number is not valid. Please try again.");
            valid = true;
        }

        for (int i = 0; i < hexadecimal.Length; i++)
        {
            number += hexadecimal[i] * (int)Math.Pow(16, i);
        }
        Console.WriteLine("The hexadecimal number in decimal representation is: {0}", number);
        Console.WriteLine();
    }
}
