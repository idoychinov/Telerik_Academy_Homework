/* Problem 10. Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 
*/
using System;
using System.Collections.Generic;
using System.Text;

class Factoriel
{
    static List<int> Multyplay(List<int> number, int multiplicator)
    {
        int carry = 0, current;
        List<int> result = new List<int>();
        for (int i = 0; i < number.Count; i++)
        {
            current = ((number[i] * multiplicator) + carry);
            result.Add(current % 10);
            carry = current / 10;
        }
        if (carry > 0)
        {
            int lenght = carry.ToString().Length;
            for (int i = 0; i < lenght; i++)
            {
                result.Add(carry % 10);
                carry = carry / 10;
            }
        }

        return result;
    }

    static string DisplayList(List<int> number)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = number.Count - 1; i >= 0; i--)
        {
            builder.Append(number[i]);
        }
        string result = builder.ToString();
        return result;
    }
    static void Main()
    {
        List<int> num = new List<int>();
        num.Add(1);
        Console.WriteLine("1! = 1");
        for (int i = 2; i <= 100; i++)
        {
            num = Multyplay(num, i);
            Console.WriteLine("{0}! = {1}", i, DisplayList(num));
        }

    }
}

