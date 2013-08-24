/*
 * Problem 14. Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
 */

using System;

class ExchangeKBits
{
    static void Main()
    {
        uint n, a, b, mask;
        bool correct;
        byte p, q, k;
        while (true)
        {
            //Input and verification
            Console.Write("Enter an unsigned integer number:");
            correct = uint.TryParse(Console.ReadLine(), out n);
            Console.WriteLine("The number is {0} in binary system", Convert.ToString(n, 2).PadLeft(32, '0'));
            Console.Write("Enter first starting bit p (0<=p<=31):");
            correct &= byte.TryParse(Console.ReadLine(), out p) & (p < 32);
            Console.Write("Enter second starting bit q (0<=q<=31):");
            correct &= byte.TryParse(Console.ReadLine(), out q) & (q < 32);
            Console.Write("Enter shift index k (1<=k<=32):");
            correct &= byte.TryParse(Console.ReadLine(), out k) & (k>0) & (k<=32) & (p+k<=32) & (q+k<=32);

            if (correct)
            {
                
                if (k > Math.Abs(p - q))  // Checks if the two sequences overlap. In this case it will determine whether to swap bits one by one if the sequences overlap or use mask and swap all in one pass if not.
                // it can be used to give an error and only accept sequences that doesn't overlap instead of using two types of swaping.
                {
                    Console.WriteLine("The two intervals of bits overlap so bit by bit swap will be performed!");
                    mask=1;
                    for (int i = 0; i < k; i++)
                    {
                        a = n & (mask << p + i);
                        b = n & (mask << q + i);
                        n = n & ~(mask << p + i);
                        n = n & ~(mask << q + 1);
                        if (p > q)
                        {
                            n = n | (a >> p - q);
                            n = n | (b << p - q);
                        }
                        else
                        {
                            n = n | (a << q - p);
                            n = n | (b >> q - p);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("The two intervals of bits doesn't overlap so swap will be performed on all bits at once!");
                    mask = (uint)Math.Pow(2,k)-1; // Bitmask will be created by substracting 1 from 2 on power k which will equal to digit represented by k number of 1s in binary format.
                    a = n & (mask << p);
                    b = n & (mask << q);
                    n = n & ~(mask << p);
                    n = n & ~(mask << q);
                    if (p > q)
                    {
                        n = n | (a >> p-q);
                        n = n | (b << p-q);
                    }
                    else
                    {
                        n = n | (a << q-p);
                        n = n | (b >> q-p);
                    }
                }
                Console.WriteLine("The number with swaped bits is {0} and in binary system {1}", n, Convert.ToString(n, 2).PadLeft(32, '0'));
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values\n");
            }
        }
    }
}