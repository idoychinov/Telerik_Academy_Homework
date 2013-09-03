/* Problem 1. Write a program that reads an integer number and calculates and prints its square root. 
 * If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.
 */
using System;

class SqrtOfInt
{
    static void Main()
    {
        Console.Write("Enter the integer number:");
        try
        {
            Console.WriteLine(Sqrt(int.Parse(Console.ReadLine())));
        }
        catch (ArgumentOutOfRangeException err)
        {
            Console.Error.WriteLine("Error: " + err.Message);
        }
        catch (FormatException err)
        {
            Console.Error.WriteLine("Error: " + err.Message);
        }
        catch (Exception err)
        {
            Console.Error.WriteLine("Error: " + err.Message);
        }
        finally
        {
            Console.WriteLine("\nGood bye");
        }
    }
    static double Sqrt(double value)
    {
        if (value < 0)
            throw new System.ArgumentOutOfRangeException();
        return Math.Sqrt(value);
    }
}

