using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02GreedyDwarf
{
    class P02GreedyDwarf
    {
        static readonly char[] Separators = { ',', ' ' };
        static void Main(string[] args)
        {
            int[] valley = ParseInputArray(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int[][] patterns = new int[M][];

            for (int i = 0; i < M; i++)
            {
                int[] temp = ParseInputArray(Console.ReadLine());
                patterns[i] = temp;
            }

            Console.WriteLine(TryAllPaths(valley, patterns));
        }

        static int[] ParseInputArray(string input)
        {
            string[] stringArr = input.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                arr[i] = int.Parse(stringArr[i]);
            }
            return arr;
        }

        static int TryPath(int[] valley, int[] path)
        {
            bool[] visited = new bool[valley.Length];
            int index = 0;
            visited[index] = true;
            int coins = valley[index];
            index = path[0];
            int pathIndex = 0;
            while (index >= 0 && index < valley.Length)
            {
                if (!visited[index])
                {
                    visited[index] = true;
                    coins += valley[index];
                }
                else
                { 
                    break; 
                }
                pathIndex++;
                pathIndex %= path.Length;
                index = index+path[pathIndex];
            }
            return coins;
        }

        static int TryAllPaths(int[] valley, int[][] paths)
        {
            int maxCoins = int.MinValue;
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                int currentCoins = TryPath(valley, paths[i]);
                if (currentCoins > maxCoins)
                {
                    maxCoins = currentCoins;
                }
            }
            return maxCoins;
        }
    }
}
