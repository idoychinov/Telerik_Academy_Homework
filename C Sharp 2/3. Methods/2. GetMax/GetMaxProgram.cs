/* Problem 2. Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest 
 * of them using the method GetMax().
*/
using System;

class GetMaxProgram
{
    static int GetMax(int x, int y)
    {
        if (x > y)
        {
            return x;
        }
        return y;
    }

    static int ReadInt(int position)
    {
        Console.Write("Please enter integer {0}:",position);
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static void Main()
    {
        int max = GetMax(ReadInt(1), GetMax(ReadInt(2), ReadInt(3)));
        Console.WriteLine("The maximum number is {0}", max);
    }
}

