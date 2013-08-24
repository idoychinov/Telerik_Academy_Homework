/*
 * Problem 12. We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
 * Example: n = 5 (00000101), p=3, v=1  13 (00001101)          n = 5 (00000101), p=2, v=0  1 (00000001)
 */

using System;

class SettBit
{
    static void Main()
    {
        int n,v,result;
        byte p;
        bool correct;

        while (true)
        {
            //Input and verification
            Console.Write("Enter an integer number:");
            correct = int.TryParse(Console.ReadLine(), out n);
            Console.Write("Enter the bit position p  (0<=p<=31):");
            correct &= (byte.TryParse(Console.ReadLine(), out p)) & (p < 32);
            Console.Write("Enter the value to set  (0 or 1):");
            correct &= (int.TryParse(Console.ReadLine(), out v)) & (v>=0) & (v<=1);
            

            if (correct)
            {
                if (v == 1)
                {
                    result = n | (1 << p);
                }
                else
                {
                    result = n & ~( 1 << p);
                }
                Console.WriteLine("The new number is {0}", result);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values\n");
            }
        }
    }
}