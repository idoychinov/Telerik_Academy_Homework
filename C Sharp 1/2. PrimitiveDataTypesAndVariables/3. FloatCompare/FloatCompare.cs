/* Problem 3.Write a program that safely compares floating-point numbers with precision of 0.000001. Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003) -> true
 */


using System;

class FloatCompare
{
    static void Main()
    {

        // Comparing double and float floating point variables can give incorect result
        // The precision of float and double comparison depends not only on the number of digits after the decimal point, but on the number of digits of the base of the number.
        // If a float number for example has 7-8 digits before the decimalpoint , a precission of 6 digits after the decimal point cannot be achieved. We can try this by changing
        // third = 1231231235f; and fourth= 1231231236f and the result will still be true 
        double first = 5.3;
        double second = 6.01;
        float third = 5.00000001f;
        float fourth =  5.00000003f;
        bool firstResult = (first == second);
        bool secondResult = (third == fourth);
        Console.WriteLine("First compare is {0}. Second compare is {1}",firstResult,secondResult);
        

        // The correct way to compare two floating point variables with preset precision

        decimal fifth = 6.000000034m; 
        decimal sixth = 6.000000021m;
        decimal seventh = 6.000034m;
        decimal eighth = 6.000021m;
        decimal precision = 0.000001m;
        bool result = false;


        if (Math.Abs(fifth - sixth) < precision) // We substract one of the numbers from the other and take the absolute value ( that way we don't care which is the bigger number we only need the absolute
                                                 // value of the difference. Then we compare it with the set precission if the result is smaller than the precission then we can say the numbers are equal.
        {
            result = true;
        }
        else
        {
            result = false;
        }
        Console.WriteLine("The result of comparing decimal numbers {0} and {1} with precision {2 } is {3}", fifth, sixth, precision, result);

        if (Math.Abs(seventh - eighth) < precision)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        Console.WriteLine("The result of comparing decimal numbers {0} and {1} with precision {2 } is {3}", seventh, eighth, precision, result);
    }
}

