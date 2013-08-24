/*
 * Problem 10. Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.
 */

using System;

class BitPValue
{
    static void Main()
    {
        int v;
        byte p;
        bool correctV, correctP,result;

        while (true)
        {
            //Input and verification
            Console.Write("Enter an integer number:");
            correctV = int.TryParse(Console.ReadLine(), out v);
            Console.Write("Enter the bit position p  (0<=p<=31):");
            correctP = (byte.TryParse(Console.ReadLine(), out p))&(p<32);
            

            if (correctP && correctV)
            {
                result = (((v>>p)&1)==1);
                Console.WriteLine("The statment that for the number {0} bit {1} is \"1\" is {2}", v, p, result);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values\n");
            }
        }
    }
}

