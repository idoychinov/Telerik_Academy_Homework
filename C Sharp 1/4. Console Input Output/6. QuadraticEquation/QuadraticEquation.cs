/*Problem 6. Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
 */

using System;
using MyIO;

class QuadraticEquation
{
    static void Main()
    {
        int coefficientA, coefficientB, coefficientC;
        double root1, root2, discriminant;
        MyIOClass.Input(out coefficientA, "Please enter coefficient A: ");
        if (coefficientA != 0)
        {
            MyIOClass.Input(out coefficientB, "Please enter coefficient B: ");
            MyIOClass.Input(out coefficientC, "Please enter coefficient C: ");
            discriminant = (coefficientB * coefficientB - (4 * coefficientA * coefficientC));
            if (discriminant > 0)
            {
                root1 = ((double)-coefficientB + Math.Sqrt(discriminant)) / (2 * coefficientA);
                root2 = ((double)-coefficientB - Math.Sqrt(discriminant)) / (2 * coefficientA);
                Console.WriteLine("The roots of the equation are {0} and {1}", Math.Min(root1, root2), Math.Max(root1, root2));
            }
            else
            {
                if (discriminant == 0)
                {
                    root1 = (double)-coefficientB / (2 * coefficientA);
                    Console.WriteLine("The equation has only one root {0}", root1);
                }
                else
                {
                    Console.WriteLine("The equation has no real roots!");
                }
            }
        }
        else
        {
            Console.WriteLine("Coeficient A can't be 0 since this will be linear equation!");
        }
    }
}