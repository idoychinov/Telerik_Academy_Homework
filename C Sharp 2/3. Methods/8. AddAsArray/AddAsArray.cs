/* Problem 8. Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
 * Each of the numbers that will be added could have up to 10 000 digits.
*/
using System;
using System.Collections.Generic;

class AddAsArray
{
    static List<char> AddIntegers(char[] first, char[] second)
    {
        int minlenght=first.Length;
        int maxlenght=second.Length;
        bool firstIsLonger=false;
        int temp;
        int carry = 0;
        List<char> result = new List<char>();
        if (first.Length > second.Length)
        {
            minlenght = second.Length;
            maxlenght = first.Length;
            firstIsLonger = true;
        }
        
        for (int i = 0; i < minlenght; i++)
        {
            temp = ((first[i] - '0') + (second[i] - '0') + carry);
            result.Add((char)( (temp%10)+ '0'));
            carry = temp / 10;
        }
        if (firstIsLonger)
        {
            for (int i = minlenght; i < maxlenght; i++)
            {
                temp = (first[i] - '0') + carry;
                result.Add((char)((temp % 10) + '0'));
                carry = temp / 10;
            }
        }
        else
        {
            for (int i = minlenght; i < maxlenght; i++)
            {
                temp = (second[i] - '0') + carry;
                result.Add((char)((temp % 10) + '0'));
                carry = temp / 10;
            }
        }
        if ((minlenght == maxlenght)&&(carry>0))
        {
            result.Add('1');
        }
        return result;
    }
    static void Main()
    {
        char[] firstNum = {'3','8','1'};
        char[] secondNum = {'2','5','8','5'};
        char[] resultArr;
        resultArr = AddIntegers(firstNum, secondNum).ToArray();
        string first, second, result;
        Array.Reverse(firstNum);
        Array.Reverse(secondNum);
        Array.Reverse(resultArr);
        result = new string(resultArr);
        first = new string(firstNum);
        second = new string(secondNum);
        Console.WriteLine(first);
        Console.WriteLine("+");
        Console.WriteLine(second);
        Console.WriteLine("=");
        Console.WriteLine(result);
    }
}
