namespace Task03CombinationsWithNoDuplicates
{
    using System;

    class Task03CombinationsWithNoDuplicates
    {
        static void Main()
        {
            int n = 4, k = 2;
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
