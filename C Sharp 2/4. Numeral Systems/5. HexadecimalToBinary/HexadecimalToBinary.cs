/* Problem 5. Write a program to convert hexadecimal numbers to binary numbers (directly).
 */

using System;
using System.Collections.Generic;

class HexadecimalToBinary
{
    static void Main()
    {
        string hexadecimal="";
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
                
                for (int i = 0; i < input.Length; i++)
                {
                    switch(input[i])
                    {
                        case '0': hexadecimal += "0000"; break;
                        case '1': hexadecimal += "0001"; break;
                        case '2': hexadecimal += "0010"; break;
                        case '3': hexadecimal += "0011"; break;
                        case '4': hexadecimal += "0100"; break;
                        case '5': hexadecimal += "0101"; break;
                        case '6': hexadecimal += "0110"; break;
                        case '7': hexadecimal += "0111"; break;
                        case '8': hexadecimal += "1000"; break;
                        case '9': hexadecimal += "1001"; break;
                        case 'a': hexadecimal += "1010"; break;
                        case 'b': hexadecimal += "1011"; break;
                        case 'c': hexadecimal += "1100"; break;
                        case 'd': hexadecimal += "1101"; break;
                        case 'e': hexadecimal += "1110"; break;
                        case 'f': hexadecimal += "1111"; break;
                        case 'A': hexadecimal += "1010"; break;
                        case 'B': hexadecimal += "1011"; break;
                        case 'C': hexadecimal += "1100"; break;
                        case 'D': hexadecimal += "1101"; break;
                        case 'E': hexadecimal += "1110"; break;
                        case 'F': hexadecimal += "1111"; break;
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
