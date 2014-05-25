namespace SortPerformance
{
    using System;
    using System.Diagnostics;

    public class SortPerformance
    {
        // Total run time of the program with ArrayLength = 10000 is around 37 seconds. You can reduce ArrayLength for faster run time. 
        private const int ArrayLength = 10000;
        private static readonly string[] OperationsTypes = new string[] { "insertion", "selection", "quick" };
        private static readonly string[] InputData = new string[] { "random", "sorted", "reverse sorted" };

        private static readonly Random Rand = new Random();

        public delegate void OpperationCall<T>(T[] array);

        public static void Main()
        {
            // Integer
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of random integers. Time elapsed: ", Benchmark<int>(OperationsTypes[0], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of sorted integers. Time elapsed: ", Benchmark<int>(OperationsTypes[0], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of reverse integers. Time elapsed: ", Benchmark<int>(OperationsTypes[0], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of random integers. Time elapsed: ", Benchmark<int>(OperationsTypes[1], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of sorted integers. Time elapsed: ", Benchmark<int>(OperationsTypes[1], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of reverse integers. Time elapsed: ", Benchmark<int>(OperationsTypes[1], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of random integers. Time elapsed: ", Benchmark<int>(OperationsTypes[2], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of sorted integers. Time elapsed: ", Benchmark<int>(OperationsTypes[2], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of reverse integers. Time elapsed: ", Benchmark<int>(OperationsTypes[2], InputData[2]));
            Console.WriteLine();

            // Double
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of random doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[0], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of sorted doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[0], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of reverse doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[0], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of random doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[1], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of sorted doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[1], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of reverse doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[1], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of random doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[2], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of sorted doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[2], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of reverse doubles. Time elapsed: ", Benchmark<double>(OperationsTypes[2], InputData[2]));
            Console.WriteLine();

            // String
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of random strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of sorted strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Inseartion sort of reverse strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of random strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of sorted strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Selection sort of reverse strings. Time elapsed: ", Benchmark<string>(OperationsTypes[0], InputData[2]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of random strings. Time elapsed: ", Benchmark<string>(OperationsTypes[2], InputData[0]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of sorted strings. Time elapsed: ", Benchmark<string>(OperationsTypes[2], InputData[1]));
            Console.WriteLine("{0,-40} {1}", "Quick sort of reverse strings. Time elapsed: ", Benchmark<string>(OperationsTypes[2], InputData[2]));
        }

        public static TimeSpan Benchmark<T>(string operation, string order) where T : IComparable
        {
            T[] array = GetInputData<T>(order);

            OpperationCall<T> opperationCall;

            switch (operation)
            {
                case "insertion":
                    opperationCall = InsertionSort<T>;
                    break;
                case "selection":
                    opperationCall = SelectionSort;
                    break;
                case "quick":
                    opperationCall = QuickSortStart;
                    break;
                default: throw new ArgumentException("No such operation type");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            opperationCall(array);

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static T[] GetInputData<T>(string order)
        {
            T[] array = new T[ArrayLength];

            for (int i = 0; i < ArrayLength; i++)
            {
                if (order == "random")
                {
                    array[i] = (T)Convert.ChangeType(Rand.Next(), typeof(T));
                }
                else
                {
                    array[i] = (T)Convert.ChangeType(i, typeof(T));
                }
            }

            if (order == "reverse sorted")
            {
                Array.Reverse(array);
            }

            return array;
        }

        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;

            for (int i = 0; i < length; i++)
            {
                dynamic value = array[i];
                int j = i - 1;
                while ((j >= 0) && (array[j].CompareTo(value) > 0))
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = value;
                }
            }
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            int min;
            T temp;
            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }

                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        public static void QuickSortStart<T>(T[] array) where T : IComparable
        {
            QuickSort<T>(array, 0, array.Length - 1);
        }

        public static void QuickSort<T>(T[] array, int left, int right) where T : IComparable
        {
            int i = left;
            int j = right;
            T pivot = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    T tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort<T>(array, left, j);
            }

            if (i < right)
            {
                QuickSort<T>(array, i, right);
            }
        }
    }
}
