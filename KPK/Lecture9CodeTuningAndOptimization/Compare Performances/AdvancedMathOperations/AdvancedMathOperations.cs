namespace AdvancedMathOperations
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathOperations
    {
        private static readonly string[] NumericTypes = new string[] { "float", "double", "decimal" };
        private static readonly string[] OperationsTypes = new string[] { "square root", "natural logarithm", "sinus" };

        public delegate void OpperationCall(dynamic operand);

        public static void Main()
        {
            ////Float
            Console.WriteLine("{0,-40} {1}", "Float addition. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Float substraction. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Float incrementation. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[2]));
            Console.WriteLine();

            ////Double
            Console.WriteLine("{0,-40} {1}", "Double addition. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Double substraction. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Double incrementation. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[2]));
            Console.WriteLine();

            ////Decimal
            Console.WriteLine("{0,-40} {1}", "Decimal addition. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Decimal substraction. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Decimal incrementation. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[2]));
        }

        public static TimeSpan Benchmark(string type, string operation)
        {
            dynamic operand;
            switch (type)
            {
                case "float":
                    operand = 23.17f;
                    break;
                case "double":
                    operand = 23.17d;
                    break;
                case "decimal":
                    operand = 23.17m;
                    break;
                default: throw new ArgumentException("No such numeric type");
            }

            OpperationCall opperationCall;

            switch (operation)
            {
                case "square root":
                    opperationCall = SquareRoot;
                    break;
                case "natural logarithm":
                    opperationCall = NaturalLogarithm;
                    break;
                case "sinus":
                    opperationCall = Sinus;
                    break;
                default: throw new ArgumentException("No such operation type");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                opperationCall((double)operand);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static void SquareRoot(dynamic operand)
        {
            Math.Sqrt(operand);
        }

        public static void NaturalLogarithm(dynamic operand)
        {
            Math.Log(operand);
        }

        public static void Sinus(dynamic operand)
        {
            Math.Sin(operand);
        }
    }
}
