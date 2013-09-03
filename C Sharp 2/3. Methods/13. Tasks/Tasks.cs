/* Problem 13. Write a program that can solve these tasks:
 * Reverses the digits of a number
 * Calculates the average of a sequence of integers
 * Solves a linear equation a * x + b = 0
 *      Create appropriate methods.
 *      Provide a simple text-based menu for the user to choose which task to solve.
 *      Validate the input data:
 *  The decimal number should be non-negative
 *  The sequence should not be empty
 *  a should not be equal to 0
*/
using System;
using System.Collections.Generic;



class Tasks
{
    static decimal InputDecimal()
    {
        decimal number;
        Console.Write("Input the number to invert:");
        do
        {
            number = decimal.Parse(Console.ReadLine());
            if (number > 0)
            {
                break;
            }
            Console.Write("Incorect input - the number must be non-negative. Try again:");
        } while (true);
        return number;
    }

    static decimal Reverse(decimal number)
    {
        string numToProcess = number.ToString();
        char[] arr = numToProcess.ToCharArray();
        Array.Reverse(arr);
        string processedNum = new string(arr);
        return decimal.Parse(processedNum);
    }

    static int[] InputSequence()
    {
        List<int> seq = new List<int>();
        string current;
        int temp;
        Console.WriteLine("Please enter the sequence (type \"end\" to stop entering numbers):");
        while (true)
        {
            current = Console.ReadLine();
            if (current == "end")
            {
                if (seq.Count == 0)
                {
                    Console.WriteLine("The sequence can't be empty, write atlease one number!");
                }
                else
                {
                    break;
                }
            }
            else
            {
                if (int.TryParse(current, out temp))
                {
                    seq.Add(temp);
                }
                else
                {
                    Console.WriteLine("Not a valid number, try again!");
                }
            }
        }
        return seq.ToArray();
    }

    static decimal CalculateAvarage(int[] seq)
    {
        int total = 0, count = seq.Length;
        foreach (int item in seq)
        {
            total += item;
        }
        return (decimal)total / count;
    }

    static void SolveEquation()
    {
        decimal a, b;
        while (true)
        {
            Console.Write("Enter a = ");
            a = decimal.Parse(Console.ReadLine());
            if (a != 0)
            {
                break;
            }
            Console.WriteLine("A should not be equal to 0!");
        }
        Console.Write("Enter b = ");
        string bDisplay="";
        b = decimal.Parse(Console.ReadLine());
        if (b > 0)
        {
            bDisplay = "+"+b.ToString();
        }
        else if(b<0)
        {
            bDisplay = b.ToString();
        }
        Console.WriteLine("The solution of the equation {0}*x{1}=0 is {2}",a,bDisplay,-b/a);
    }

    static void Main()
    {
        bool active = true;
        while (active)
        {
            Console.WriteLine("TASKS:");
            Console.WriteLine("1 - Reverse digits of number");
            Console.WriteLine("2 - Calculate average of sequence of integers");
            Console.WriteLine("3 - Solve linear equation a*x+b=0");
            Console.WriteLine("ESC - exit program");
            Console.WriteLine("Please chose a task by clicking the apropriate keyboard key!");
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo();
            keyPressed = Console.ReadKey(true);
            switch (keyPressed.KeyChar)
            {
                case '1': Console.WriteLine("\nThe inverted decimal is {0}\n", Reverse(InputDecimal())); break;
                case '2': Console.WriteLine("\nThe avarage of the sequence is {0}\n", CalculateAvarage(InputSequence())); break;
                case '3': SolveEquation(); break;
                case '\u001B': active = false; break;
                default: break;
            }
            Console.WriteLine();
        }
    }
}

