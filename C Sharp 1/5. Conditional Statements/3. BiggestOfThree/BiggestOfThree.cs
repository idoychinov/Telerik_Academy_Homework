/* Problem 3. Write a program that finds the biggest of three integers using nested if statements.
 */
using System;
using MyIO;

class BiggestOfThree
{
    static void Main()
    {
        int firstNumber, secondNumber, thirdNumber;

        MyIOClass.Input(out firstNumber, "Please enter the first number: ");
        MyIOClass.Input(out secondNumber, "Please enter the second number: ");
        MyIOClass.Input(out thirdNumber, "Please enter the third number: ");

        if (firstNumber > secondNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The first number is the biggest of the three!");
            }
            else
            {
                if (firstNumber == thirdNumber)
                {
                    Console.WriteLine("The first and the third numbers are equal and bigger then the second!");
                }
                else
                {
                    Console.WriteLine("The third number is the biggest of the three!");
                }
            }
        }
        else
        {
            if (secondNumber > thirdNumber)
            {
                if (secondNumber == firstNumber)
                {
                    Console.WriteLine("The first and the second numbers are equal and bigger then the third!");
                }
                else
                {
                    Console.WriteLine("The second number is the biggest of the three!");
                }
            }
            else
            {
                if (secondNumber == thirdNumber)
                {
                    if (secondNumber == firstNumber)
                    {
                        Console.WriteLine("The three numbers are equal!");
                    }
                    else
                    {
                        Console.WriteLine("The second and the third numbers are equal and bigger then the first!");
                    }
                }
                else
                {
                    Console.WriteLine("The third number is the biggest of the three!");
                }
            }
        }
    }
}

