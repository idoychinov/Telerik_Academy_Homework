/*
 * Problem 5. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
 */

using System;

class ThirdBit
{
    static void Main()
    {
        int number;

        byte bitPosition = 3;
        byte result;
        int mask = 1 << bitPosition;
        while (true)
        {
            Console.Write("Enter an integer number:");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if ((number & mask) == mask)    // Boolean expression that evaluates if the bit at position 3 in this case is 1 or 0. After the bitwise AND of the number with the mask the result will be
                {                               // thath only the third bit will retain it's original value, all other will be 0. And after we compare this result with the mask which have the same bit  
                    result = 1;                 //set to 1 we can tell if the bit is 1 or 0
                }
                else
                {
                    result = 0;
                }
                Console.WriteLine("The bit at position {0} of the number {1} is {2}\nThe number {1} in binary representation is {3}", bitPosition, number, result, Convert.ToString(number, 2).PadLeft(32, '0'));

                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct integer number!\n");
            }
        }
    }
}

