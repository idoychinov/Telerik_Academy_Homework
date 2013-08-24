/* Problem 13. Create a program that assigns null values to an integer and to double variables. Try to print them on the console, try to add some values or the null literal to them and see the result.
 */

using System;

class NullValues
{
    static void Main()
    {
        int? integerNumber = null;
        double? doubleNumber = null;
        Console.WriteLine("Integer: {0}; Double: {1}",integerNumber,doubleNumber);
        integerNumber = integerNumber + 2;
        doubleNumber = doubleNumber + 3.12;
        Console.WriteLine("Integer: {0}; Double: {1}", integerNumber, doubleNumber); // the result of the binary operation is null if one or both operands are null
        integerNumber = integerNumber + null;
        doubleNumber = doubleNumber + null;
        Console.WriteLine("Integer: {0}; Double: {1}", integerNumber, doubleNumber); // same as above
        integerNumber = integerNumber.GetValueOrDefault() + 2;
        doubleNumber = doubleNumber.GetValueOrDefault() + 3.12;
        Console.WriteLine("Integer: {0}; Double: {1}", integerNumber, doubleNumber); 
    }
}

