/*
 * Problem 1. Write an expression that checks if given integer is odd or even.
 */

using System;

class OddOrEven
{
    static void Main()
    {
        uint number;
        while (true)
        {
            Console.Write("Enter a positve integer number:");
            if (uint.TryParse(Console.ReadLine(), out number)) // Tries to parse the input from the console. If it's not appropriate positive integer then a message is displayed and the program waits for another input.
            {
                string result;

                if (number % 2 == 0)
                {
                    result = "even";
                }
                else
                {
                    result = "odd";
                }
                Console.WriteLine("The number {0} is {1}",number,result);
                break;  // Exits the while loop afther an correct integer is evaluated.
            }
            else
            {
                Console.WriteLine("\nPlease enter correct integer number!\n");
            }
        }
    }
}
