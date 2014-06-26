namespace Lection01.DSAAndComplexity
{
    using System;
    using System.Diagnostics;

    class DataStructuresAndComplexity
    {

        // Task 1. What is the expected running time of the following C# code? Explain why. Assume the array's size is n.

        // Answer: The expected runing time is O(n*n) or Quadratic complexity, since the outher loop will run n times and the inner loop will also run n times for each iteration of the outer.
        // The inner loop runs from 0 to n with each iteration moving either the start or the end by one. This means that the inner loop will execute n*n times.
        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                    if (arr[start] < arr[end])
                    { start++; count++; }
                    else
                        end--;
            }
            return count;
        }

        // Task 2. What is the expected running time of the following C# code? Explain why.

        // Answer: The expected runing time is O(n*m) or Quadratic complexity for worst case scenario. The outher loop runs n times and the inner loop runs m times if each first element of each row
        // is odd. The best case is if each first element on each row is even in which case the only the outer loop will execute.
        static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
                if (matrix[row, 0] % 2 == 0)
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        if (matrix[row, col] > 0)
                            count++;
            return count;
        }

        // Task 3. What is the expected running time of the following C# code? Explain why.

        // Answer: The algorithm is recursive and also if n>m the program will crash since col is checked against row lenght and gives index out of range exeption. If n<m the loop will executre n
        // times each time calling the same method wich will executre n times or O(n*n) - n Square.
        // If the change is made to compare col to matrix.GetLenght(1) and row to matrix.GetLenght(0) the comlexity of the algorithm is O(n*m) since this is recursive suming of the matrix cells.

        static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
                sum += matrix[row, col];
            if (row + 1 < matrix.GetLength(0))
                sum += CalcSum(matrix, row + 1);
            return sum;
        }


        /// <summary>
        /// Contains benchmarks in order to confirm the assumed answers.
        /// </summary>
        static void Main()
        {
            const int Elements = 2000;
            const int Multiplyer = 5;
            const int SecondMultiplyer = 3;

            double ratio;
            Stopwatch timer = new Stopwatch();
            TimeSpan firstRun;
            TimeSpan secondRun;

            // Task 1 test
            int[] arr1 = new int[Elements];
            int[] arr2 = new int[Elements * Multiplyer];

            timer.Start();
            Compute(arr1);
            timer.Stop();
            firstRun = timer.Elapsed;

            timer.Restart();
            Compute(arr2);
            timer.Stop();
            secondRun = timer.Elapsed;

            ratio = secondRun.TotalMilliseconds / firstRun.TotalMilliseconds;

            Console.WriteLine("The Compute algorithm is {0} times slower when the input is {1} times larger, or approximately {1} square ", ratio, Multiplyer);
            Console.WriteLine();

            // Task 2 test
            const int N = 200;
            const int M = 750;


            int[,] matrix1 = new int[N, M];
            int[,] matrix2 = new int[N * Multiplyer, M * SecondMultiplyer];
            int[,] oddMatrix = new int[N, M];

            // initialize first row with odd elements
            for (int i = 0; i < N; i++)
            {
                oddMatrix[i, 0] = 1;
            }

            //Test complexity in worst case

            timer.Restart();
            CalcCount(matrix1);
            timer.Stop();
            firstRun = timer.Elapsed;

            timer.Restart();
            CalcCount(matrix2);
            timer.Stop();
            secondRun = timer.Elapsed;

            ratio = secondRun.TotalMilliseconds / firstRun.TotalMilliseconds;

            Console.WriteLine("The CalcCount algorithm is {0} times slower when the input matrix is {1}x{2} times larger, or approximately N_Increase*M_Increase ",
                ratio, Multiplyer, SecondMultiplyer, Multiplyer * SecondMultiplyer);
            Console.WriteLine();

            //Test complexity in best case

            timer.Restart();
            CalcCount(oddMatrix);
            timer.Stop();
            firstRun = timer.Elapsed;

            timer.Restart();
            CalcCount(matrix1);
            timer.Stop();
            secondRun = timer.Elapsed;

            ratio = secondRun.TotalMilliseconds / firstRun.TotalMilliseconds;

            Console.WriteLine("The CalcCount algorithm is {0} times faster when the input matrix is with all even first column elements.",
                ratio, Multiplyer, SecondMultiplyer, Multiplyer * SecondMultiplyer);
            Console.WriteLine();


            // Task 3 test

            //Test complexity in worst case

            timer.Restart();
            CalcSum(matrix1, 0);
            timer.Stop();
            firstRun = timer.Elapsed;

            timer.Restart();
            CalcSum(matrix2, 0);
            timer.Stop();
            secondRun = timer.Elapsed;

            ratio = secondRun.TotalMilliseconds / firstRun.TotalMilliseconds;

            Console.WriteLine("The CalcSum algorithm is {0} times slower when the input matrix is {1}x{2} times larger, or approximately N_Increase*M_Increase ",
                ratio, Multiplyer, SecondMultiplyer, Multiplyer * SecondMultiplyer);
            Console.WriteLine();
        }
    }
}
