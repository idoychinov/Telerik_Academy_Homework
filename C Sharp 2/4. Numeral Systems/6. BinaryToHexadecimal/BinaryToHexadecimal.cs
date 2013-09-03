/* Problem 6. Write a program to convert binary numbers to hexadecimal numbers (directly).
 */

using System;
using System.Collections.Generic;

class BinaryToHexadecimal
{
    static void Main()
    {
        string hexadecimal = "";
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
                if (input.Length % 4 != 0)
                {
                    string temp = new string('0', 4 - (input.Length % 4));
                    input = temp + input;
                }
                
                for (int i = 0; i < input.Length/4; i++)
                {
                    
                    switch (input.Substring(i*4,4))
                    {
                        case "0000": hexadecimal += '0'; break;
                        case "0001": hexadecimal += '1'; break;
                        case "0010": hexadecimal += '2'; break;
                        case "0011": hexadecimal += '3'; break;
                        case "0100": hexadecimal += '4'; break;
                        case "0101": hexadecimal += '5'; break;
                        case "0110": hexadecimal += '6'; break;
                        case "0111": hexadecimal += '7'; break;
                        case "1000": hexadecimal += '8'; break;
                        case "1001": hexadecimal += '9'; break;
                        case "1010": hexadecimal += 'A'; break;
                        case "1011": hexadecimal += 'B'; break;
                        case "1100": hexadecimal += 'C'; break;
                        case "1101": hexadecimal += 'D'; break;
                        case "1110": hexadecimal += 'E'; break;
                        case "1111": hexadecimal += 'F'; break;
                        
                    }
                   
                }
                break;
            }
            Console.WriteLine("The entered number is not valid. Please try again.");
            valid = true;
        }


        Console.WriteLine("The hexadecimal number in decimal representation is: {0}", hexadecimal);
        Console.WriteLine();
    }
}
