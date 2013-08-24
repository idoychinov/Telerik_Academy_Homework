/*
 * Problem 8. Write an expression that calculates trapezoid's area by given sides a and b and height h.
 */

using System;

class Trapezoid
{
    static void Main()
    {
        byte sideA,sideB,height;
        bool correctA,correctB,correctH;
         while (true)
        {
            Console.Write("Enter side a:");
            correctA=byte.TryParse(Console.ReadLine(), out sideA);
            Console.Write("Enter side b:");
            correctB=byte.TryParse(Console.ReadLine(), out sideB);
            Console.Write("Enter height:");
            correctH=byte.TryParse(Console.ReadLine(), out height);
            if (correctA&correctB&correctH) // Tries to parse the input from the console. If it's not appropriate positive byte then a message is displayed and the program waits for another input.
            {
                double area;
                area = ((double)(sideA + sideB) / 2) * height; // the formula for calculating area of trapezoid is K=((a+b)/2)*h. We need to typecast the sum of a and b in floating point otherwise the / operator
                                                       // will perform integer division and return the result without the fractional part.
                Console.WriteLine("The area of the trapezoid is {0}", area);
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct values for both sides a and b and for height\n");
            }
         }
    }
}
        