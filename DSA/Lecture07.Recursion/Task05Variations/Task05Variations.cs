namespace Task05Variations
{
    using System;
    using System.Linq;

    class Task05Variations
    {
        private static string[] set = new[] { "hi", "a", "b" };

        internal static void Main()
        {
            int n = set.Length;
            int k = 2;

            if (!(0 < k && k <= n))
            {
                throw new InvalidOperationException();
            }

            Variate(0, n, k, new int[k]);
        }

        private static void Variate(int current, int n, int k, int[] variation)
        {
            if (current == k)
            {
                Console.Write("({0}), ", string.Join(", ", variation.Select(i => set[i])));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                variation[current] = i;
                Variate(current + 1, n, k, variation);
            }
        }
    }
}
