using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P01_9GagNumbers
{
    class P01_9GagNumbers
    {
        static string[] systemDigintsList = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        static void Main()
        {
            string input = Console.ReadLine();
            BigInteger output = OtherToDecimal(ParseNumber(input));
            Console.WriteLine(output);
        }


        static BigInteger OtherToDecimal(int[] input)
        {

            BigInteger number = 0;
            BigInteger currentPosition = 1;
            for (int i = 0; i < input.Length; i++)
            {
                number += input[i] * currentPosition;
                currentPosition *= systemDigintsList.Length;
            }
            return number;
        }

        static int[] ParseNumber(string input)
        {
            int currentIndex = 0;
            List<int> number = new List<int>(input.Length);
            while (currentIndex < input.Length)
            {
                for (int i = 0; i < systemDigintsList.Length; i++)
                {

                    int match = input.IndexOf(systemDigintsList[i], currentIndex);
                    if (match == currentIndex)
                    {
                        number.Add(i);
                        currentIndex += systemDigintsList[i].Length;
                        break;
                    }
                }
            }
            number.Reverse(); // arrange elements in accending order by their position 
            return number.ToArray();
        }
    }
}
