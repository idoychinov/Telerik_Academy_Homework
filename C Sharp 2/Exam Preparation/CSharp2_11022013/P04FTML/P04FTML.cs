using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04FTML
{
    /// <summary>
    /// UNFINISHED 60/100
    /// </summary>
    class P04FTML
    {
        static string[] allTags = { "<upper>", "<lower>", "<toggle>", "<del>", "<rev>", "</upper>", "</lower>", "</toggle>", "</del>", "</rev>" };

        enum SearchOptions { Open, Close, Both };

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                Console.WriteLine(FormatLine(line));
            }
        }

        private static string FormatLine(string line)
        {
            StringBuilder output = new StringBuilder(line.Length);
            Stack<string> process = new Stack<string>();
            Stack<string> tags = new Stack<string>();
            int currentIndex = 0;
            int processedIndex = 0;
            // can be done with stack and que -  better...
            Stack<string> reverse = new Stack<string>();
            
            while (currentIndex < line.Length)
            {
                
                char currentChar = line[currentIndex];
                if (currentChar != '<')
                {
                    currentIndex++;
                }
                else
                {
                    string unprocessed = line.Substring(processedIndex, currentIndex - processedIndex);
                    if (unprocessed.Length > 0)
                    {
                        process.Push(unprocessed);
                    }//?
                    if (line[currentIndex + 1] != '/')
                    {
                        
                        int tagEnd = line.IndexOf('>', currentIndex);
                        process.Push(line.Substring(currentIndex,tagEnd-currentIndex+1));
                        currentIndex=tagEnd+1;
                        processedIndex = currentIndex;
                    }
                    else
                    {
                        int tagEnd = line.IndexOf('>', currentIndex);
                        string closeTag = line.Substring(currentIndex, tagEnd - currentIndex + 1);
                        string openTag = allTags[Array.IndexOf(allTags, closeTag) - (allTags.Length / 2)];
                        currentIndex = tagEnd + 1;
                        processedIndex = currentIndex;
                        //Queue<string> temp = new Queue<string>();
                        //while(process.Peek()!=openTag)//if end of the line
                        //{
                        //    temp.Enqueue();
                        //}
                        
                        while (process.Peek() != openTag)
                        {
                            reverse.Push(process.Pop());
                        }
                        StringBuilder temp = new StringBuilder();
                        while (reverse.Count != 0)
                        {
                            temp.Append(reverse.Pop());
                        }
                        process.Pop();
                        process.Push(TagProcess(temp.ToString(), openTag));
                        
                    }
                }
            }
            if (currentIndex != processedIndex)
            {
                process.Push(line.Substring(processedIndex, currentIndex - processedIndex));
            }
            reverse.Clear();
            while (process.Count != 0) 
            {
                reverse.Push(process.Pop());
            }
            while (reverse.Count != 0)
            {
                output.Append(reverse.Pop());
            }

            //string currentTag = "";
            //Stack<string> tags = new Stack<string>();
            //int tagIndex = FindFirstTag(line, out currentTag, SearchOptions.Open);
            //if (tagIndex < 0)
            //{
            //    return line;
            //}
            //else
            //{
            //    output.Append(line.Substring(0, tagIndex));
            //    currentIndex = tagIndex;
            //    tags.Push(currentTag);
            //}
            //while (currentIndex < line.Length)
            //{

            //}
            return output.ToString();
        }

        private static string TagProcess(string input, string openTag)
        {
            if (openTag == allTags[0])
            {
                return input.ToString().ToUpper();
            }
            if (openTag == allTags[1])
            {
                return input.ToString().ToLower();
            }
            if (openTag == allTags[2])
            {
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] >= 'a' && input[i] <= 'z')
                    {
                        temp.Append((char)(input[i]-32));
                    }
                    else if (input[i] >= 'A' && input[i] <= 'Z')
                    {
                        temp.Append((char)(input[i] + 32));
                    }
                    else
                    {
                        temp.Append(input[i]);
                    }
                }
                return temp.ToString();
            }
            if (openTag == allTags[3])
            {
                return string.Empty;                
            }
            if (openTag == allTags[4])
            {
                StringBuilder temp = new StringBuilder();
                for (int i = input.Length-1; i >= 0; i--)
                {
                    temp.Append(input[i]);
                }
                return temp.ToString();
            }
            throw new ArgumentException("Error! No such tag");
        }

        private static int FindFirstTag(string line, out string tag, SearchOptions s)
        {

            int start = 0;
            tag = "";
            int end = allTags.Length;
            if (s == SearchOptions.Open)
            {
                end = allTags.Length / 2;
            }
            else if (s == SearchOptions.Close)
            {
                start = allTags.Length / 2;
            }

            int found = int.MaxValue;
            bool tagFound = false;
            for (int i = start; i < end; i++)
            {
                int current = line.IndexOf(allTags[i]);

                if (current >= 0 && current < found)
                {
                    found = current;
                    tag = line.Substring(current, line.IndexOf(">", current) - current + 1);
                    tagFound = true;
                }
            }

            if (tagFound)
            {
                return found;
            }

            return -1;
        }


    }
}
