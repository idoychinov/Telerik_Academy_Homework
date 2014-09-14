namespace Task06StringCombinations
{
    using System;
    using System.Linq;

    class Task06StringCombinations
    {
        private static string[] set = new[] { "test", "rock", "fun", };

        internal static void Main()
        {
            int n = set.Length;
            int k = 2;

            if (!(0 < k && k <= n))
            {
                throw new InvalidOperationException();
            }

            Combinate(0, n, k, new int[k]);
        }

        private static void Combinate(int p, int n, int k, int[] comb)
        {
            if (p == k)
            {
                Console.Write("({0}), ", string.Join(" ", comb.Select(x => set[x])));
                return;
            }

            int i = (p == 0) ? 0 : comb[p - 1] + 1;
            for (; i < n; i++)
            {
                comb[p] = i;
                Combinate(p + 1, n, k, comb);
            }
        }
    }
}
