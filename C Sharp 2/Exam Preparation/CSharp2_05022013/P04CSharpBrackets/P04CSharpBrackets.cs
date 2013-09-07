using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04CSharpBrackets
{
    class P04CSharpBrackets
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string indentation = Console.ReadLine();
            string[] input=new string[N];
            for (int i = 0; i < N; i++)
            {
                string temp = Console.ReadLine();
                input[i]= Regex.Replace(temp,@"\s+"," "); 
            }

            int currentIndent = 0;
            Queue<string> output= new Queue<string>();
            for (int i = 0; i < N; i++)
            {
                StringBuilder indent = new StringBuilder();
                for (int j = 0; j < currentIndent; j++)
                {
                    indent.Append(indentation);
                }
                output.Enqueue(indent.ToString());
                int searchindex = input[i].IndexOf('{');
                while(true)
                {
                }
            }


            PrintResult(output);
        }
  
        private static void PrintResult(Queue<string> output)
        {
            StringBuilder ouputline = new StringBuilder();
            while (output.Count() != 0)
            {
                if (output.Peek() != "\n")
                {
                    ouputline.Append(output.Dequeue());
                }
                else
                {
                    output.Dequeue();
                    Console.WriteLine(ouputline.ToString());
                    ouputline.Clear();
                }
            }
        }
    }
}
