/*
 * Problem 13. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
 */

using System;

class Exchange3Bits
{
    static void Main()
    {
        uint n, a, b, mask;
        bool correct;

        while (true)
        {
            //Input and verification
            Console.Write("Enter an unsigned integer number:");
            correct = uint.TryParse(Console.ReadLine(), out n);
            
            if (correct)
            {
                Console.WriteLine("The original number {0} in binary system is {1}",n,Convert.ToString(n,2).PadLeft(32,'0'));
                mask = 7; // 7 is 111 in binary and we can use it as a bitmask.
                a = n & (mask << 3);
                b = n & (mask << 24);
                n = n & ~(mask << 3);
                n = n & ~(mask << 24);
                n = n | (a << 21);
                n = n | (b >> 21);
                Console.WriteLine("The number with swaped bits is {0} and in binary system {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct value\n");
            }
        }
    }
}