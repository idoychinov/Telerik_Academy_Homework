/*
 * Problem 4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true
 */

using System;

class CheckDigit
{
    static void Main()
    {
        // Initializing with the givend conditions, but the program can work with any digit (from 0 to 9) and any position (within the 32 bit range of uint)
        byte digit = 7;
        byte position = 3;
        int number;
      
        while (true)
        {
            Console.Write("Enter an integer number:");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if(((Math.Abs(number)/(int) Math.Pow(10, position - 1))%10)==digit)  // First we devide the absolute value of the entered number to 10^position-1 in this case 100 in order to have the 
                                                                                     // digit at the position we are looking for as last digit of the number. Then we find the remaider when divided by 10 
                                                                                     // and we get only the last digit. We compare it to the digit we have in the problem requirement to find out if it's the sought out digit.
                {
                    Console.WriteLine("The digit {0} IS the {1}th digit of the entered number",digit,position);
                }
                else
                {
                    Console.WriteLine("The digit {0} IS NOT the {1}th digit of the entered number",digit,position);
                }
                
                break;
            }
            else
            {
                Console.WriteLine("\nPlease enter correct integer number!\n");
            }
        }
    }
}
