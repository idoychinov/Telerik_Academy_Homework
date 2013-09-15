using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;//only for testing
using System.Text;
using System.Threading.Tasks;

///
///  5. Featuring with Grisko
///


namespace Problem05
{
    class Problem05
    {
        static Dictionary<char, int> uniqueLetters = new Dictionary<char, int>();
        static int length;
        static int letterCount;
        static void Main()
        {
            //only for testing
            string file = @"..\..\..\t6.txt";
            if (File.Exists(file))
            {
                Console.SetIn(new StreamReader(file));
            }
            //only for testing
            string word = Console.ReadLine();
            length = word.Length;
            foreach (var item in word)
            {
                if (uniqueLetters.ContainsKey(item))
                {
                    uniqueLetters[item]++;
                }
                else
                {
                    uniqueLetters.Add(item, 1);
                }
            }

            letterCount = uniqueLetters.Count;

            if (letterCount % 2 == 0)
            {

            }
            int result = Factoriel(length);
            int repetitions = 0;
            foreach (var item in uniqueLetters)
            {
                if (item.Value > 1)
                {
                    repetitions += item.Value;
                }
            }
            Console.WriteLine(result / Factoriel(repetitions));

        }

        static int Factoriel(int unique)
        {
            int result = 1;
            for (int i = 1; i <= unique; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
