using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P01DurankulakNumbers
{
    class P01DurankulakNumbers
    {
        static void Main()
        {
            string[] digitList = GenerateDigitsList(168);
            Console.WriteLine(OtherToDecimal(Console.ReadLine(), digitList));
        }

        static string[] GenerateDigitsList(int systemBase)
        {
            string[] list = new string[systemBase];


            for (int i = 0; i < systemBase; i++)
            {
                int cycle = (i / 26) - 1;
                char sufix = (char)('A' + (i % 26));
                if (cycle < 0)
                {
                    list[i] = sufix.ToString();
                }
                else
                {
                    char prefix = (char)('a' + cycle);
                    list[i] = String.Concat(prefix, sufix);
                }
            }

            return list;
        }

        static int[] ParseNumber(string input, string[] systemDigintsList)
        {
            int currentIndex = 0;
            List<int> number = new List<int>(input.Length);
            while (currentIndex < input.Length)
            {
                int found;
                if ((found = Array.IndexOf(systemDigintsList, input[currentIndex].ToString())) > -1)
                {
                    number.Add(found);
                    currentIndex++;
                }
                else
                {
                    if (currentIndex + 1 < input.Length)
                    {
                        if ((found = Array.IndexOf(systemDigintsList, input.Substring(currentIndex, 2))) > -1)
                        {
                            number.Add(found);
                            currentIndex += 2;
                        }
                        
                    }
                }
                
            }
            return number.ToArray();
        }

        static BigInteger OtherToDecimal(string input, string[] systemDigintsList)
        {
            BigInteger number=0;
            int[] numArray;
            numArray = ParseNumber(input, systemDigintsList);
            BigInteger currentPosition = 1; 
            for (int i = 0; i < numArray.Length; i++)
            {
                number += numArray[numArray.Length - 1 - i] * currentPosition;
                currentPosition *= systemDigintsList.Length;
            }
            return number;
        }
    }
}
