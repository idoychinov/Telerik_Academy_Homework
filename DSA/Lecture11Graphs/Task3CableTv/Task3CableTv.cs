namespace Task3CableTv
{

    using System;


    class Task3CableTv
    {
        static void Main()
    {
        var adjMatrix = BuildGraph();
        FindMinSpanningTree(adjMatrix);
    }

    static void FindMinSpanningTree(int[,] adjMatrix)
    {
        Console.WriteLine("Edges in the minimum spanning tree (using Prim):");

        int n = adjMatrix.GetLength(0);
        var used = new bool[n];
        var previous = new int[n];
        var minCostCache = new int[n];

        used[0] = true; 
        for (int i = 0; i < n; i++)
            minCostCache[i] = (adjMatrix[0, i] != 0) ? adjMatrix[0, i] : int.MaxValue;

        int totalCost = 0;
        for (int k = 0; k < n - 1; k++)
        {

            int minCost = int.MaxValue;
            int j = -1;
            for (int i = 0; i < n; i++)
            {
                if (!used[i] && minCostCache[i] < minCost)
                {
                    minCost = minCostCache[i];
                    j = i;
                }
            }

            used[j] = true;
            Console.Write("({0}, {1}) ", previous[j] + 1, j + 1);
            totalCost += minCost;

            for (int i = 0; i < n; i++)
            {
                if (!used[i] && adjMatrix[j, i] != 0 && minCostCache[i] > adjMatrix[j, i])
                {
                    minCostCache[i] = adjMatrix[j, i];

                    previous[i] = j;
                }
            }
        }

        Console.WriteLine("\nThe cost of the minimum spanning tree is {0}.", totalCost);
    }

    static int[,] BuildGraph()
    {
        return new int[,]
        {
            { 0,  1, 0,  2,  0,  0,  0, 0,  0 },
            { 1,  0, 3,  0, 13,  0,  0, 0,  0 },
            { 0,  3, 0,  4,  0,  3,  0, 0,  0 },
            { 2,  0, 4,  0,  0, 16, 14, 0,  0 },
            { 0, 13, 0,  0,  0, 12,  0, 1, 13 },
            { 0,  0, 3, 16, 12,  0,  1, 0,  1 },
            { 0,  0, 0, 14,  0,  1,  0, 0,  0 },
            { 0,  0, 0,  0,  1,  0,  0, 0,  0 },
            { 0,  0, 0,  0, 13,  1,  0, 0,  0 }
        };
    }
    }
}
