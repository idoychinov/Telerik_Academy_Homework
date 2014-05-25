namespace ArithmeticalOperations
{
    using System;
    using System.Diagnostics;

    public class ArithmeticalOperations
    {
        private static readonly string[] NumericTypes = new string[] { "int", "long", "float", "double", "decimal" };
        private static readonly string[] OperationsTypes = new string[] { "add", "substract", "increment", "multiply", "divide" };

        public delegate void OpperationCall(dynamic operand1, dynamic operand2);

        public static void Main()
        {
            ////Integer
            Console.WriteLine("{0,-40} {1}", "Integer addition. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Integer substraction. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Integer incrementation. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[2]));
            Console.WriteLine("{0,-40} {1}", "Integer multiplication. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[3]));
            Console.WriteLine("{0,-40} {1}", "Integer division. Time elapsed: ", Benchmark(NumericTypes[0], OperationsTypes[4]));
            Console.WriteLine();

            ////Long
            Console.WriteLine("{0,-40} {1}", "Long addition. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Long substraction. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Long incrementation. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[2]));
            Console.WriteLine("{0,-40} {1}", "Long multiplication. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[3]));
            Console.WriteLine("{0,-40} {1}", "Long division. Time elapsed: ", Benchmark(NumericTypes[1], OperationsTypes[4]));
            Console.WriteLine();

            ////Float
            Console.WriteLine("{0,-40} {1}", "Float addition. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Float substraction. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Float incrementation. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[2]));
            Console.WriteLine("{0,-40} {1}", "Float multiplication. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[3]));
            Console.WriteLine("{0,-40} {1}", "Float division. Time elapsed: ", Benchmark(NumericTypes[2], OperationsTypes[4]));
            Console.WriteLine();

            ////Double
            Console.WriteLine("{0,-40} {1}", "Double addition. Time elapsed: ", Benchmark(NumericTypes[3], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Double substraction. Time elapsed: ", Benchmark(NumericTypes[3], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Double incrementation. Time elapsed: ", Benchmark(NumericTypes[3], OperationsTypes[2]));
            Console.WriteLine("{0,-40} {1}", "Double multiplication. Time elapsed: ", Benchmark(NumericTypes[3], OperationsTypes[3]));
            Console.WriteLine("{0,-40} {1}", "Double division. Time elapsed: ", Benchmark(NumericTypes[3], OperationsTypes[4]));
            Console.WriteLine();

            ////Decimal
            Console.WriteLine("{0,-40} {1}", "Decimal addition. Time elapsed: ", Benchmark(NumericTypes[4], OperationsTypes[0]));
            Console.WriteLine("{0,-40} {1}", "Decimal substraction. Time elapsed: ", Benchmark(NumericTypes[4], OperationsTypes[1]));
            Console.WriteLine("{0,-40} {1}", "Decimal incrementation. Time elapsed: ", Benchmark(NumericTypes[4], OperationsTypes[2]));
            Console.WriteLine("{0,-40} {1}", "Decimal multiplication. Time elapsed: ", Benchmark(NumericTypes[4], OperationsTypes[3]));
            Console.WriteLine("{0,-40} {1}", "Decimal division. Time elapsed: ", Benchmark(NumericTypes[4], OperationsTypes[4]));
        }

        public static TimeSpan Benchmark(string type, string operation)
        {
            dynamic operand1;
            dynamic operand2;
            switch (type)
            {
                case "int":
                    operand1 = 100;
                    operand2 = 17;
                    break;
                case "long":
                    operand1 = 100L;
                    operand2 = 17L;
                    break;
                case "float":
                    operand1 = 100f;
                    operand2 = 17f;
                    break;
                case "double":
                    operand1 = 100d;
                    operand2 = 17d;
                    break;
                case "decimal":
                    operand1 = 100m;
                    operand2 = 17m;
                    break;
                default: throw new ArgumentException("No such numeric type");
            }

            OpperationCall opperationCall;

            switch (operation)
            {
                case "add":
                    opperationCall = Addition;
                    break;
                case "substract":
                    opperationCall = Substraction;
                    break;
                case "increment":
                    opperationCall = Incrementation;
                    break;
                case "multiply":
                    opperationCall = Multiplication;
                    break;
                case "divide":
                    opperationCall = Divison;
                    break;
                default: throw new ArgumentException("No such operation type");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                opperationCall(operand1, operand2);
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static void Addition(dynamic operand1, dynamic operand2)
        {
            var result = operand1 + operand2;
        }

        public static void Substraction(dynamic operand1, dynamic operand2)
        {
            var result = operand1 - operand2;
        }

        public static void Incrementation(dynamic operand1, dynamic operand2)
        {
            var result = operand1++;
        }

        public static void Multiplication(dynamic operand1, dynamic operand2)
        {
            var result = operand1 * operand2;
        }

        public static void Divison(dynamic operand1, dynamic operand2)
        {
            var result = operand1 / operand2;
        }
    }
}
