namespace Task12Stack
{
    using System;

    public class Task12Stack
    {
        public static void Main()
        {
            const int Iterations = 5;
            Stack<int> stack = new Stack<int>();

            Console.WriteLine("Put in Stack\n");
            for (int i = 0; i < Iterations; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack.Peek());
            }

            Console.WriteLine("\n\nGet from Stack\n");
            for (int i = 0; i < Iterations; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
