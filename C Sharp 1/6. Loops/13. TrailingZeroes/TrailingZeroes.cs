using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        int zeroCount = 0;
        Console.Write("Please enter your number:");
        BigInteger number =BigInteger.Parse( Console.ReadLine());
        
        while (true)
        {
            if (number%10 !=0||number==0)
            {
                break;
            }
            else
            {
                zeroCount++;
            }
            number /= 10;
        }
        Console.WriteLine("The trailing zeroes are: "+zeroCount);
    }
}

