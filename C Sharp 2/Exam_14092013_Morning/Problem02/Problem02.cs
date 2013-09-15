using System;
using System.Collections.Generic;
using System.IO;//only for testing
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///
/// 2. Magic Words
///

namespace Problem02
{
    class Problem02
    {
        static void Main()
        {
            //only for testing
            string file = @"..\..\..\t7.txt";
            if (File.Exists(file))
            {
                Console.SetIn(new StreamReader(file));
            }
            //only for testing
            int n = int.Parse(Console.ReadLine());
            //string[] words = new string[n];
            List<string> words = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            Reorder(words);
            Print(words);

        }

        static void Reorder(List<string> words)
        {
            int n = words.Count;
            for (int i = 0; i < words.Count; i++)
            {
                string current = words[i];
                int len = current.Length;
                int newPos = len % (n + 1);
                words.Insert(newPos, current);
                if (newPos >= i)
                {
                    words.RemoveAt(i);
                }
                else
                {
                    words.RemoveAt(i + 1);
                }
            }
        }

        static void Print(List<string> words)
        {
            StringBuilder output = new StringBuilder();
            int cycle = 0;
            while (true)
            {
                bool printing = false;

                for (int i = 0; i < words.Count; i++)
                {
                    if (cycle < words[i].Length)
                    {
                        output.Append(words[i][cycle]);
                        printing = true;
                    }
                }
                if (!printing)
                {
                    break;
                }
                cycle++;
            }
            Console.WriteLine(output.ToString());
        }
    }
}
