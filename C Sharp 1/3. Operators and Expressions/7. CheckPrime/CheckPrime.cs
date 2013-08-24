/*
 * Problem 7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
 */

using System;

class CheckPrime
{
    static void Main()
    {
        byte number;
        byte factor;
        bool isPrime = false;

        while (true)
        {
            Console.Write("Enter a positve integer number between 2 and 100:");
            if (byte.TryParse(Console.ReadLine(), out number)&&(number<=100)&&(number>=2)) // Tries to parse the input from the console. If it's not appropriate positive byte then a message is displayed and the program waits for another input.
            {
                factor = (byte)Math.Truncate(Math.Sqrt(number)); // If a number is not prime it can be factored into two factors y=a*b. If both factors were greater than the square root of the original number
                                                                 // their product would be greater then it. So at least one of them is less then the square root of y. If we test the numbers up to the square 
                                                                 // root of y, and find that non of them are factors of y then y is prime.

                if (number==2)
                {
                    isPrime = true; // 2 is the only even prime number. All other even numbers has 2 for a factor so non of them can be prime.
                }
                else 
                {
                    if (number % 2 == 0)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        isPrime = true;
                        for (int i = 3; i < factor; i++)
                        {
                            if (number % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                            i++;
                        }
                    }
                }
                Console.Write("The number {0} ",number);
                if (isPrime)
                {
                    Console.WriteLine("IS prime");
                }
                else
                {
                    Console.WriteLine("IS NOT prime");
                }
                break;  // Exits the while loop afther an correct number is evaluated.
            }
            else
            {
                Console.WriteLine("\nPlease enter correct integer number!\n");
            }
        }
    }
}

