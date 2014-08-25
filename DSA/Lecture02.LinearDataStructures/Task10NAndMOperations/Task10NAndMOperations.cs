namespace Task10NAndMOperations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// * We are given numbers N and M and the following operations:
    /// N = N+1
    /// N = N+2
    /// N = N*2
    /// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
    /// Example: N = 5, M = 16
    /// Sequence: 5  7  8  16
    /// </summary>
    public class Task10NAndMOperations
    {
        public static void Main()
        {
            int n;
            int m;

            Console.WriteLine("Enter N and M such as N<M");
            do
            {
                Console.Write("Enter N: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Enter M: ");
                m = int.Parse(Console.ReadLine());
            }
            while (n >= m);

            Queue<long> queue = new Queue<long>();
            Stack<long> stepHistory = new Stack<long>();
            Stack<long> previousNumber = new Stack<long>();

            long current, multiplyed, plusOne, plusTwo;

            queue.Enqueue(n);

            do
            {
                current = queue.Dequeue();
                multiplyed = current * 2;
                plusTwo = current + 2;
                plusOne = current + 1;

                if (multiplyed <= m && !stepHistory.Contains(multiplyed))
                {
                    stepHistory.Push(multiplyed);
                    previousNumber.Push(current);
                    queue.Enqueue(multiplyed);
                }

                if (plusTwo <= m && !stepHistory.Contains(plusTwo))
                {
                    stepHistory.Push(plusTwo);
                    previousNumber.Push(current);
                    queue.Enqueue(plusTwo);
                }

                if (plusOne <= m && !stepHistory.Contains(plusOne))
                {
                    stepHistory.Push(plusOne);
                    previousNumber.Push(current);
                    queue.Enqueue(plusOne);
                }
            } 
            while (current != m);

            Stack<long> outputSteps = new Stack<long>();

            while (stepHistory.Count > 0)
            {
                if (current == stepHistory.Pop())
                {
                    outputSteps.Push(current);
                    current = previousNumber.Pop();
                }
                else
                {
                    previousNumber.Pop();
                }
            }

            outputSteps.Push(n);
            Console.WriteLine(string.Join(" -> ", outputSteps));
        }
    }
}
