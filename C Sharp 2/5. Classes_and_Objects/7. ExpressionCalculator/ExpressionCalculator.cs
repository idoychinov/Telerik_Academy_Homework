/* * Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
 * Real numbers, e.g. 5, 18.33, 3.14159, 12.6
 * Arithmetic operators: +, -, *, / (standard priorities)
 * Mathematical functions: ln(x), sqrt(x), pow(x,y)
 * Brackets (for changing the default priorities)
 * Examples:
 * (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
 * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
 */
using System;
using System.Linq;

class ExpressionCalculator
{
    static void Main()
    {
        Console.WriteLine("Enter the arithmetical expression you want calculated:");
        string input = Console.ReadLine();
        string output = CalculateExpression(input);
        Console.WriteLine("The expression evaluates to:\n{0}", output);
        
    }

    private static string CalculateExpression(string input)
    {
        bool partOfNumber = false;
        string number="";
        string output="";
        for (int i = 0; i < input.Length; i++)
        {
            if(IsNum(input[i]))
            {
                number = string.Concat(number, input[i]);
                partOfNumber = true;
            }
            else
            {
                if (partOfNumber)
                {
                    double.Parse(number);// add push to queue
                    partOfNumber = false;
                    number = "";
                }
                else
                {
                    //check for operation
                }
            }
        }
        return output; //add real output
    }

    private static bool IsNum(char p)
    {
        if ((p >= '0' && p <= '9') || p == '.')
        {
            return true;
        }
        return false;
    }

    
}

