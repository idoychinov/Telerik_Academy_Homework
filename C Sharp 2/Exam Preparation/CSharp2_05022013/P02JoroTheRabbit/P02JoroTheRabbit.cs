using System;

namespace P02JoroTheRabbit
{   
    class P02JoroTheRabbit
    {
        private static int[] terrain;
        private static readonly char[] separators = { ',', ' ' };
        static void Main()
        {
            terrain = ParseInputArray(Console.ReadLine());
            Console.WriteLine(TryAllPaths());
        }

        static int[] ParseInputArray(string input)
        {
            string[] stringArr = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                arr[i] = int.Parse(stringArr[i]);
            }
            return arr;
        }

        static int TryAllPaths()
        {
            int bestPath = 0;
            for (int startIndex = 0; startIndex < terrain.Length; startIndex++)
            {
                for (int step = 1; step < terrain.Length; step++)
                {
                    int index = startIndex;
                    int path=1;
                    int next = (index + step);
                    if (next >= terrain.Length)
                    {
                        next = (index + step) % terrain.Length;
                    }
                    while(terrain[index]<terrain[next])
                    {
                        path++;
                        index = next;
                        next = (index + step);
                        if (next >= terrain.Length)
                        {
                            next = (index + step) % terrain.Length;
                        }
                    }
                    if (path > bestPath)
                    {
                        bestPath = path;
                    }
                }
            }
            return bestPath;
        }
    }
}
