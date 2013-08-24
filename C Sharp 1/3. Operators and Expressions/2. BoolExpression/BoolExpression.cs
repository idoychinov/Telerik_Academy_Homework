/*
 * Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
 */

using System;

class BoolExpression
{
    static void Main()
    {
        uint number;
        while (true)
        {
            Console.Write("Enter a positve integer number:");
            if (uint.TryParse(Console.ReadLine(), out number)) // Tries to parse the input from the console. If it's not appropriate positive integer then a message is displayed and the program waits for another input.
            {
                bool devision;
                devision = (number % 5 == 0) && (number % 7 == 0); // The expression that evaluates the number.
                if (devision)
                {
                    Console.WriteLine("The number {0} CAN be devided by both 5 and 7 without remainder.", number);
                }
                else
                {
                    Console.WriteLine("The number {0} CAN NOT be devided by both 5 and 7 without remainder.", number);
                }
                break;  // Exits the while loop afther an correct integer is evaluated.
            }
            else
            {
                Console.WriteLine("\nPlease enter correct integer number!\n");
            }
        }
    }
}

