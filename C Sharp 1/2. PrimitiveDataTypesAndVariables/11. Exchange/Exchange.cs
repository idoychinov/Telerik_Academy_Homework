/* Problem 11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
 */
using System;

class Exchange
{
    static void Main()
    {
        int first = 5;
        int second = 10;
        int temp;

        temp = first;
        first = second;
        second = temp;
        Console.WriteLine("Values after exchange: {0} {1}",first,second);
    }
}
