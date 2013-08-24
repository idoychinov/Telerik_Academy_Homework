/* Problem 8. Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

 */
using System;
using MyIO; //using methods defined in another project within the solution.

class GCD
{
    static void Main()
    {
        long firstNum,secondNum,gcd,condition,temp;

        while (true)
        {
            MyIOClass.Input(out firstNum, "Enter the number N: ");
            MyIOClass.Input(out secondNum, "Enter the number K: ");
            if ((firstNum > 1)&&(secondNum > 1))
            {
                break;
            }
            Console.WriteLine("Both numbers must be positive and above 0!\n");
        }

        gcd = firstNum;
        condition = secondNum;
        // Euclidean division algoritam
        while (condition != 0)
        {
            temp = condition;
            condition = gcd % temp;
            gcd = temp;
        }

        Console.WriteLine("The greatest common divisor of {0} and {1} is: {2}",firstNum,secondNum, gcd);

    }
}

