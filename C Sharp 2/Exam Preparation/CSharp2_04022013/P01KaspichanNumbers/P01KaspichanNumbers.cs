using System;
using System.Numerics;
using System.Text;

namespace P01KaspichanNumbers
{
    class P01KaspichanNumbers
    {
        static void Main()
        {
            string[] digitList = GenerateDigitsList(256);
            string input = Console.ReadLine();
            Console.WriteLine(DecimalToOther(input,digitList));
        }

        static string[] GenerateDigitsList(int systemBase)
        {
            string[] list = new string[systemBase];
            
            
            for (int i = 0; i < systemBase; i++)
            {
                int cycle = (i / 26)-1;
                char sufix = (char)('A' + (i % 26));
                if (cycle<0)
                {
                    list[i] = sufix.ToString();
                }
                else
                {
                    char prefix = (char)('a'+cycle);
                    list[i] = String.Concat(prefix, sufix);
                }
            }

            return list;
        }

        static string DecimalToOther(string input, string[] systemDigitsList)
        {
            BigInteger number = BigInteger.Parse(input);
            StringBuilder output = new StringBuilder(input.Length);
            do
            {
                int current = (int)(number % systemDigitsList.Length);
                output.Insert(0,(systemDigitsList[current]));
                number /= systemDigitsList.Length;
            } while (number != 0) ;
            
            return output.ToString();
        }

    }
}
