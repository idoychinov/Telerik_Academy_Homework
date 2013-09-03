/* Problem 9. * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
 * Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
 */

// compile with: /unsafe
using System;
using System.Globalization;

class FloatBinaryRepresentation
{
    static void Main()
    {
        float number;
        Console.Write("Please enter number of type float:");
        while (!float.TryParse(Console.ReadLine(),NumberStyles.Any, CultureInfo.InvariantCulture, out number))
        {
            Console.Write("Incorect Input, try again:");
        }

        byte[] byteArray=BitConverter.GetBytes(number);
        Array.Reverse(byteArray);
        string result="";
        foreach (var item in byteArray)
        {
            result += Convert.ToString(item, 2).PadLeft(8, '0');
        }
        Console.WriteLine("\nThe binary representation of the number is:\nSign = {0}\nExponent = {1}\nMantis = {2}", result.Substring(0,1),result.Substring(1,8),result.Substring(9));
    }

}
