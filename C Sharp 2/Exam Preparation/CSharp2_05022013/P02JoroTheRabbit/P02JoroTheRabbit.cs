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
            int maxJumps = int.MinValue;
            for (int i = 0; i < terrain.Length; i++)
            {
                int currentJumps = TryAllSteps(i);
                if (currentJumps > maxJumps)
                {
                    maxJumps = currentJumps;
                }
            }
            return maxJumps;
        }

        private static int TryAllSteps(int startPosition)
        {
            int maxJumps = int.MinValue;
            for (int i = 1; i < terrain.Length; i++)
            {
                int currentJumps = TryStep(startPosition,i);
                if (currentJumps > maxJumps)
                {
                    maxJumps = currentJumps;
                }
            }
            return maxJumps;
        }

        private static int TryStep(int startPosition, int step)
        {
            bool[] visited = new bool[terrain.Length];
            int jumps = 0;
            int currentPosition = startPosition;
            int value = int.MinValue;
            while (!visited[currentPosition])
            {
                if (terrain[currentPosition] <= value)
                {
                    break;
                }
                value = terrain[currentPosition];
                jumps++;
                visited[currentPosition] = true;
                currentPosition = (currentPosition + step) % terrain.Length;

            }
            return jumps;
        }
    }
}
