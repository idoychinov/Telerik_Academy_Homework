/* Problem 2. Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
 */
using System;
using MyIO; //using methods defined in another project within the solution.

class ProductSign
{
    static void Main()
    {
        double firstNumber, secondNumber, thirdNumber;
        bool positiveSign=false;

        MyIOClass.Input(out firstNumber, "Please enter the first number: ");
        MyIOClass.Input(out secondNumber, "Please enter the second number: ");
        MyIOClass.Input(out thirdNumber, "Please enter the third number: ");

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("The product is 0");
        }
        else
        {
            if (firstNumber >= 0)
            {
                positiveSign = true;
            }
            if ((secondNumber >= 0 && positiveSign) || (secondNumber < 0 && !positiveSign))
            {
                positiveSign = true;
            }
            else
            {
                positiveSign = false;
            }
            if ((thirdNumber >= 0 && positiveSign) || (thirdNumber < 0 && !positiveSign))
            {
                Console.WriteLine("The sign of the product is positive");
            }
            else
            {
                Console.WriteLine("The sign of the product is negative");
            }
        }
    }
}

