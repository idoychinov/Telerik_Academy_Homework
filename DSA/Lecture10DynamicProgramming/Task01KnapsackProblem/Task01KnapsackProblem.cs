namespace Task01KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Task01KnapsackProblem
    {
        private static List<Item> items = new List<Item>()
        {
            new Item("beer", 3, 2),
            new Item("vodka", 8, 12),
            new Item("cheese", 4, 5),
            new Item("nuts", 1, 4),
            new Item("ham", 2, 3),
            new Item("whiskey", 8, 13),
        };

        static void Main()
        {
            int maxCapacity = 10;

            var itemsInBag = GetItems(items, maxCapacity);

            foreach (var item in itemsInBag)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Total weight: {0}\nTotal cost: {1}", itemsInBag.Sum(p => p.Weight), itemsInBag.Sum(p => p.Value));
        }

        public static IEnumerable<Item> GetItems(IList<Item> items, int maxCapacity)
        {
            int[,] table = new int[items.Count + 1, maxCapacity + 1];
            for (int row = 1; row <= items.Count; row++)
            {
                var item = items[row - 1];
                for (int col = 0; col <= maxCapacity; col++)
                {
                    if (item.Weight > col)
                    {
                        table[row, col] = table[row - 1, col];
                    }
                    else
                    {
                        table[row, col] = Math.Max(
                            table[row - 1, col],
                            table[row - 1, col - item.Weight] + item.Value);
                    }
                }
            }

            var takeItems = new List<Item>();
            for (int row = items.Count, col = maxCapacity; row > 0; row--)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    takeItems.Add(items[row - 1]);
                    col -= items[row - 1].Weight;
                }
            }

            return takeItems;
        }
    }
}
