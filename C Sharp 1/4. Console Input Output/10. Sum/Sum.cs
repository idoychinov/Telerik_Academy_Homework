/*Problem 10. Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
 */

using System;
using MyIO;

class Numbers1ToN
{
    static void Main()
    {
        uint n;
        decimal sum=0,temp;
        MyIOClass.Input(out n);
        for (int i = 1; i <= n; i++)
        {
            temp = Math.Round(1.0m / i, 3, MidpointRounding.AwayFromZero);// rounding up to the third digit after the decimal point (accuracity 0.001). The MidpointRounding.AwayFromZero clause is used in order to round 5 up instead of down.
            sum += temp;
        }
        Console.WriteLine("The sum is: {0}",sum);
    }
}