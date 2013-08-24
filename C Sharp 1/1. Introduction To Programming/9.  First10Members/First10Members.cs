// 9. Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class First10Members
{
    static void Main()
    {
        int startNumber = 2;    // Starting number for the sequence. Can be easily changed if needed.
        int count = 10;     // Number of members for the sequence.
        bool sign = true;  // Flag that indicates wether the number in the sequence should be positive or negative.

        for (int i = startNumber; i < startNumber + count; i++) // Loop that creates the sequence.
        {
            if (sign)
            {
                Console.Write(i);
            }
            else
            {
                Console.Write(i * -1);
            }
            Console.Write("  ");
            sign = !sign; // Changes the sign for the next iteration
        }
    }
}

