using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02SpecialValue
{
    class P02SpecialValue
    {
        static int[][] allRows;
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            allRows = new int[N][];
            for (int i = 0; i < N; i++)
			{			
                string[] line = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                int[] row = line.Select(x => int.Parse(x)).ToArray();
                allRows[i] = row;
            }

            int maxSpecialValue = int.MinValue;
            for (int i = 0; i < allRows[0].Length; i++)
            {
                int pathSpecialValue = CalculatePath(i,N);
                if (pathSpecialValue > maxSpecialValue)
                {
                    maxSpecialValue = pathSpecialValue;
                }
            }
            Console.WriteLine(maxSpecialValue);
        }
  
        private static int CalculatePath(int start,int N)
        {
            bool[][] visited = new bool[N][];
            for (int i = 0; i < N; i++)
            {
                visited[i]=new bool[allRows[i].Length];
            }
            
            int stepCount = 0;
            int rowIndex = 0;
            int colIndex = start;

            while (rowIndex < N)
            {
                stepCount++;
                if (visited[rowIndex][colIndex])
                {
                    return int.MinValue;
                }
                if (allRows[rowIndex][colIndex] < 0)
                {
                    return stepCount + Math.Abs(allRows[rowIndex][colIndex]);
                }
                visited[rowIndex][colIndex] = true;
                colIndex = allRows[rowIndex][colIndex];
                rowIndex++;
                if (rowIndex >= N)
                {
                    rowIndex -= N;
                }
            }

            return int.MinValue;
        }
    }
}
