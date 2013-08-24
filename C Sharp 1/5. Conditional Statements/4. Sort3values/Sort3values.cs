/* Problem 4. Sort 3 real values in descending order using nested if statements.
 */
using System;
using MyIO;

class Sort3values
{
    static void Main()
    {
        double firstNumber, secondNumber, thirdNumber;

        MyIOClass.Input(out firstNumber, "Please enter the first number: ");
        MyIOClass.Input(out secondNumber, "Please enter the second number: ");
        MyIOClass.Input(out thirdNumber, "Please enter the third number: ");

        if (firstNumber >= secondNumber)
        {
            if (secondNumber >= thirdNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
            }
            else
            {
                if (firstNumber >= thirdNumber)
                {
                    Console.WriteLine("{0}, {1}, {2}", firstNumber, thirdNumber, secondNumber);
                }
                else
                {
                    Console.WriteLine("{0}, {1}, {2}", thirdNumber, firstNumber, secondNumber);
                }
            }
        }
        else
        {
            if (firstNumber>=thirdNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", secondNumber, firstNumber, thirdNumber);
            }
            else
            {
                if (secondNumber >= thirdNumber)
                {
                    Console.WriteLine("{0}, {1}, {2}", secondNumber, thirdNumber, firstNumber);
                }
                else
                {
                    Console.WriteLine("{0}, {1}, {2}", thirdNumber, secondNumber, firstNumber);
                }
            }
        }
    }
}

