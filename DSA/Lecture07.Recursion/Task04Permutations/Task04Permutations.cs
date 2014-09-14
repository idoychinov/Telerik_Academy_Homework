namespace Task04Permutations
{
    using System;

    class Task04Permutations
    {

        static void Main()
        {
            var n = 3;
            GeneratePermutations(0, n, new int[n], new bool[n]);
        }

        static void GeneratePermutations(int current, int n, int[] permutation, bool[] used)
        {
            if (current == n)
            {
                Console.Write("(" + string.Join(", ", permutation) + "), ");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if(used[i])
                {
                    continue;
                }

                permutation[current] = i + 1;
                used[i] = true;
                GeneratePermutations(current + 1, n, permutation, used);
                used[i] = false;
            }

        }
    }
}
