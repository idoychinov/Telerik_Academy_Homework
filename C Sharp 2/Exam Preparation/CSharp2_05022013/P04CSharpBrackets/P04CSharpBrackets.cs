using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace P04CSharpBrackets
{
    /// <summary>
    /// INCOMPLEATE  60/100
    /// </summary>
    class P04CSharpBrackets
    {
        static void Main()
        {
            if (File.Exists("tin.txt"))
            {
                Console.SetIn(new StreamReader("tin.txt"));
            }

            int N = int.Parse(Console.ReadLine());
            string indentation = Console.ReadLine();
            string[] input = new string[N];
            List<string> clearInput = new List<string>();
            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                string temp=Regex.Replace(line, @"\s+", " ");
                if(temp!=string.Empty)
                {
                    clearInput.Add(temp);
                }
            }

            input = clearInput.ToArray();
            N = input.Length;
            

            int currentIndent = 0;
            Queue<string> output = new Queue<string>();
            for (int i = 0; i < N; i++)
            {
                int index = 0;
                string currentLine = input[i];
                StringBuilder tempText = new StringBuilder();
                while (index < input[i].Length)
                {
                    // somewhere here empty indented row is added before brackets 
                    char currentChar = currentLine[index];

                    if (currentChar == '{' || currentChar == '}')
                    {
                        StringBuilder indentAddition = new StringBuilder(currentIndent * indentation.Length);
                        for (int j = 0; j < currentIndent; j++)
                        {
                            indentAddition.Append(indentation);
                        }
                        if (tempText.Length != 0)
                        {
                            output.Enqueue(indentAddition.ToString() + tempText.ToString().Trim());
                            output.Enqueue("\n");
                        }
                        if (currentChar == '}')
                        {
                            currentIndent--;
                            indentAddition.Remove(indentAddition.Length - indentation.Length, indentation.Length);
                        }
                        output.Enqueue(indentAddition.ToString() + currentChar.ToString());
                        output.Enqueue("\n");
                        if (currentChar == '{')
                        {
                            currentIndent++;
                        }
                        index++;
                        tempText.Clear();
                    }
                    else
                    {
                        tempText.Append(currentChar);
                        index++;
                    }
                }
                if(tempText.Length !=0)
                {
                    StringBuilder indentAddition = new StringBuilder(currentIndent * indentation.Length);
                    for (int j = 0; j < currentIndent; j++)
                    {
                        indentAddition.Append(indentation);
                    }
                    output.Enqueue(indentAddition.ToString() + tempText.ToString().Trim());
                    output.Enqueue("\n");
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
