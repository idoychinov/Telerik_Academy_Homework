/* Problem 7. Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
 */

using System;

class ConvertToAnyBase
{
    static char[] mapping = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

    static void Main()
    {

        string input;
        int s, d;

        Console.Write("Enter the input number base (between 2 and 16):");
        s = ValidateBases();

        Console.Write("Enter the input number (use symbols from  0 to {0}:", mapping[s - 1]);
        input = ValidateInput(s);

        Console.Write("Enter the output number base (between 2 and 16):");
        d = ValidateBases();

        Console.WriteLine("The number {0} in {1} base is represented in {2} based system as {3}", input, s, d, ConvertFromDecimalBased(ConvertToDecimalBased(input, s), d));
    }

    private static int ValidateBases()
    {
        int output;
        bool valid = false;
        while (true)
        {
            valid = int.TryParse(Console.ReadLine(), out output) && (output >= 2) && (output <= 16); //input validation
            if (valid)
            {
                break;
            }
            Console.WriteLine("Incorect input, please try again.");
        }
        return output;
    }

    private static string ValidateInput(int lenght)
    {
        string output;
        char[] localMapping = new char[lenght];
        Array.Copy(mapping, localMapping, lenght);
        while (true)
        {
            bool valid = true;
            output = Console.ReadLine();
            foreach (char item in output)  // check if all symbols in the input are part of the predefined mapping of allowed symbols
            {
                if (Array.BinarySearch(localMapping, item) < 0)
                {
                    valid = false;
                }
            }
            if (valid)
            {
                break;
            }
            Console.WriteLine("Incorect input, please try again.");
        }
        return output;
    }

    private static int ConvertToDecimalBased(string input, int inbase)
    {
        int output = 0;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            output += Array.BinarySearch(mapping, input[i]) * (int)Math.Pow(inbase, input.Length - 1 - i);
        }

        return output;
    }

    private static string ConvertFromDecimalBased(int number, int inbase)
    {
        string output = "";
        while (true)
        {
            output = mapping[number % inbase] + output;
            number /= inbase;
            if (number == 0)
            {
                break;
            }
        }

        return output;
    }



}

