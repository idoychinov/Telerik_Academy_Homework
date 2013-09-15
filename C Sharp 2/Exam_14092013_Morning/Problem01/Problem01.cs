using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; // only for testing
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

///
/// 1. Multiverse Communication
///

namespace Problem01
{
    class Problem01
    {
        static string[] systemDigitsList = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI",
                                             "CAD", "K-A", "IIA", "YLO","PLA" };
        static void Main()
        {
            //only for testing
            string file = @"..\..\..\t3.txt";
            if (File.Exists(file))
            {
                Console.SetIn(new StreamReader(file));
            }
            //only for testing
            int[] parsedNumber = ParseNumber(Console.ReadLine());
            Console.WriteLine(OtherToDecimal(parsedNumber));
        }

        static int[] ParseNumber(string input)
        {
            int currentIndex = 0;
            List<int> number = new List<int>(input.Length);
            while (currentIndex < input.Length)
            {
                for (int i = 0; i < systemDigitsList.Length; i++)
                {

                    int match = input.IndexOf(systemDigitsList[i], currentIndex);
                    if (match == currentIndex)
                    {
                        number.Add(i);
                        currentIndex += systemDigitsList[i].Length;
                        break;
                    }
                }
            }
            number.Reverse(); // arrange elements in accending order by their position 
            return number.ToArray();
        }

        static BigInteger OtherToDecimal(int[] input)
        {

            BigInteger number = 0;
            BigInteger currentPosition = 1;
            for (int i = 0; i < input.Length; i++)
            {
                number += input[i] * currentPosition;
                currentPosition *= systemDigitsList.Length;
            }
            return number;
        }
    }
}
