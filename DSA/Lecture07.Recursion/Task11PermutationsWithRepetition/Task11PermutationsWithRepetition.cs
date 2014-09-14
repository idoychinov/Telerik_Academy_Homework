namespace Task11PermutationsWithRepetition
{
    using System;

    class Task11PermutationsWithRepetition
    {
        internal static void Main()
    {
        var set1 = new[] { 1, 3, 5, 5 };
        var set2 = new[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        var set = set1;
        Array.Sort(set);

        Permutate(set, 0, new int[set.Length], new bool[set.Length]);
    }

    private static void Permutate(int[] set, int p, int[] perm, bool[] used)
    {
        if (p == set.Length)
        {
            Console.WriteLine(string.Join(", ", perm));
            return;
        }

        perm[p] = int.MinValue;
        for (int i = 0; i < set.Length; i++)
        {
            if (!used[i] && set[i] > perm[p])
            {
                perm[p] = set[i];
                used[i] = true;
                Permutate(set, p + 1, perm, used);
                used[i] = false;
            }
        }
    }
    }
}
