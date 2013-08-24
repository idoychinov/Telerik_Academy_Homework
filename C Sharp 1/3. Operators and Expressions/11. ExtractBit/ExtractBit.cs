/*
 * Problem 11. Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.
 */

using System;

class ExtractBit
{
    static void Main()
    {
        int i,result;
        byte b;
        bool correctB, correctI;

        while (true)
        {
            //Input and verification
            Console.Write("Enter an integer number:");
            correctI = int.TryParse(Console.ReadLine(), out i);
            Console.Write("Enter the bit position b  (0<=b<=31):");
            correctB = (byte.TryParse(Console.ReadLine(), out b)) & (b < 32);
            

            if (correctB && correctI)
            {
                result = ((i >> b) & 1);
                Console.WriteLine("The bit at position {0} from the number {1} is {2}", b, i, result);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values\n");
            }
        }
    }
}