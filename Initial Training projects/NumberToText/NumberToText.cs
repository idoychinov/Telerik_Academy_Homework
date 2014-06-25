/* Problem 11. Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
 * 0  "Zero"
 * 273  "Two hundred seventy three"
 * 400  "Four hundred"
 * 501  "Five hundred and one"
 * 711  "Seven hundred and eleven"

 */
using System;
using MyIO;

class NumberToText
{
    static string UpToNineghteen(int num)
    {
        switch (num)
        {
            case 1: return "One";
            case 2: return "Two";
            case 3: return "Three";
            case 4: return "Four";
            case 5: return "Five";
            case 6: return "Six";
            case 7: return "Seven";
            case 8: return "Eight";
            case 9: return "Nine";
            case 11: return "Eleven";
            case 12: return "Twelve";
            case 13: return "Thirteen";
            case 14: return "Fourteen";
            case 15: return "Fifteen";
            case 16: return "sixteen";
            case 17: return "seventeen";
            case 18: return "eighteen";
            case 19: return "nineteen";
            default: return "";
        }
    }
    static string Tens(int tens)
    {
        switch (tens)
        {
            case 10: return "Ten";
            case 20: return "Twenty";
            case 30: return "Thirty";
            case 40: return "Fourty";
            case 50: return "Fifty";
            case 60: return "Sixty";
            case 70: return "Seventy";
            case 80: return "Eighty";
            case 90: return "Ninety";
            default: return "";
        }
    }
    static void Main()
    {
        ushort number;
        string textNumber = "";
        bool hundreds = false; ;
        MyIOClass ConsoleIO = new MyIOClass();

        while (true)
        {
            ConsoleIO.Input(out number, "Please enter a number in the range [0...999]: ");
            if (number < 1000)
            {
                break;
            }
            else
            {
                Console.WriteLine("\nThe value you entered is incorect!\n");
            }
        }

        if (number == 0)
        {
            Console.WriteLine("The number is: Zero");
        }
        else
        {
            if (number > 99)
            {
                hundreds = true;
                textNumber = UpToNineghteen(number / 100) + " hundred";
                number %= 100;
            }
            if (number % 10 == 0)
            {
                if (hundreds)
                {
                    if (number != 0)
                    {
                        textNumber = textNumber + " and " + Tens(number);
                    }
                }
                else
                {
                    textNumber = Tens(number);
                }
            }
            else if (number < 20)
            {
                if (hundreds)
                {
                    textNumber = textNumber + " and " + UpToNineghteen(number);
                }
                else
                {
                    textNumber = UpToNineghteen(number);
                }
            }
            else
            {
                if (hundreds)
                {
                    textNumber = textNumber + " and " + Tens((number / 10) * 10) + " " + UpToNineghteen(number % 10);
                }
                else
                {
                    textNumber = Tens((number / 10) * 10) + " " + UpToNineghteen(number % 10);
                }
            }
            Console.WriteLine("The number is: {0}", textNumber);
        }


    }
}

