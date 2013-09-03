/* Problem 3. Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".
*/
using System;

class Last_digit
{
    static string LastDigit(int number)
    {
        number = Math.Abs(number)%10;
        switch (number)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
        }
        return "";
    }
    static void Main()
    {
        Console.Write("Enter number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("The last digit of the number {0} is {1}", number, LastDigit(number));
    }
}

