/* Problem 3. Write a program to convert decimal numbers to their hexadecimal representation.
 */

using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    static void Main()
    {
        List<char> hexadecimal = new List<char>();
        int number,temp;
        while (true)
        {
            Console.Write("Enter the number:");
            if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
            {
                break;
            }
            Console.WriteLine("Incorect input try again!");
        }
        do
        {
            temp = number % 16;
            if (temp < 10)
            {
                hexadecimal.Add((char)(temp+48));
            }
            else
            {
                switch (temp)
                {
                    case 10: hexadecimal.Add('A'); break;
                    case 11: hexadecimal.Add('B'); break;
                    case 12: hexadecimal.Add('C'); break;
                    case 13: hexadecimal.Add('D'); break;
                    case 14: hexadecimal.Add('E'); break;
                    case 15: hexadecimal.Add('F'); break;
                }
            }
            number = number / 16;
        } while (number > 0);
        hexadecimal.Reverse();
        Console.Write("The decimal number in hexadecimal representation is: ");

        foreach (int item in hexadecimal)
        {
            Console.Write((char)item);
        }
        Console.WriteLine();
    }
}
