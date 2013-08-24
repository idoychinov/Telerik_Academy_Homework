/* Problem 2. Write a program that reads the radius r of a circle and prints its perimeter and area.
 */

using System;
using MyIO;
using System.Threading;
using System.Globalization;


class Circle
{
    static void Main()
    {
        float radius, pi = 3.14f;
        Thread.CurrentThread.CurrentCulture =CultureInfo.InvariantCulture; // used to ensure the decimal separator is .

        MyIOClass.Input(out radius, "Please enter the circle radius: ");
        Console.WriteLine("The circle's Perimeter is {0:F2} and it's Area is {1:F2} ", 2 * pi * radius, pi * radius * radius);

    }
}

