using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04ConsoleJustification
{
   

    class P04ConsoleJustification
    {
        readonly static char[] splitSeparators = { ' ' };
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int W = int.Parse(Console.ReadLine());
            string input = FormatInput(N);
            string[] words = input.Split(splitSeparators, StringSplitOptions.RemoveEmptyEntries);
            Justify(words, W);
        }

        private static void Justify(string[] words, int W)
        {
            List<string> output = new List<string>();
            StringBuilder currentRow = new StringBuilder();
            foreach (var item in words)
            {
                if (currentRow.Length + item.Length <= W)
                {
                    currentRow.Append(item + " ");
                }
                else
                {
                    if (currentRow[currentRow.Length - 1] == ' ')
                    {
                        currentRow.Remove(currentRow.Length - 1, 1);
                    }
                    int index=0;
                    while (currentRow.Length < W )
                    {
                        index=currentRow.ToString().IndexOf(' ',index);
                        if (index < 0)
                        {
                            index = currentRow.ToString().IndexOf(' ', 0);
                        }
                        while(currentRow[index+1]==' ')
                        {
                            index++;
                        }
                        if(index<0 ||index >W)
                        {
                            break;
                        }
                        currentRow.Insert(index, ' ');
                        index += 2;
                    }
                    output.Add(currentRow.ToString());
                    currentRow.Clear();
                    currentRow.Append(item + " ");
                }
            }
            if (currentRow.Length>1)
            {
                output.Add(currentRow.ToString().Trim());
            }
            PrintLines(output);
        }

        private static void PrintLines(List<string> lines)
        {
            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }
        static string FormatInput(int N)
        {
            StringBuilder input = new StringBuilder(N);
            for (int i = 0; i < N; i++)
            {
                input.Append(Console.ReadLine()+" ");
            }
            string output = Regex.Replace(input.ToString(),@"\s+"," ");             
            return output;
        }
    }
}
