namespace Task02StackReverse
{
    using System;
    using System.Collections.Generic;

    class Task02StackReverse
    {
        static void Main()
        {
            Stack<int> sequence = new Stack<int>();
            string line;

            Console.WriteLine("Enter sequence of integers each on new line. End the sequence with empty line");

            line = Console.ReadLine();
            while (line != String.Empty)
            {
                sequence.Push(int.Parse(line));
                line = Console.ReadLine();
            }

            while (sequence.Count > 0)
            {
                Console.WriteLine(sequence.Pop());
            }
        }
    }
}
