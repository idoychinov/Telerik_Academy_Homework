namespace Task02CombinationsWithDuplicates
{
    using System;

    class Task02CombinationsWithDuplicates
    {
        static void Main()
        {
            int n = 3, k = 2;
            GenerateCombinations(0, k, n, new int[k]);
            Console.WriteLine();
        }

        static void GenerateCombinations(int current, int k, int n, int[] combination)
        {
            if(current>=k)
            {
                Console.Write("("+string.Join(", ",combination)+"), ");
                return;
            }

            for (int i = (current == 0 ? 1 : combination[current-1]+1); i <= n; i++)
            {
                combination[current] = i;
                GenerateCombinations(current+1,k,n,combination);
            }
        }
    }
}
