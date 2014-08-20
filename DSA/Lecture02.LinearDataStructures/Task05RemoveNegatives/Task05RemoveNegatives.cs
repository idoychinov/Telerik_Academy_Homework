namespace Task05RemoveNegatives
{
    using System;
    using System.Collections.Generic;

    public class Task05RemoveNegatives
    {
        public static void Main()
        {
            List<int> sequence = new List<int>();
            string line;

            Console.WriteLine("Enter sequence of integers each on new line. End the sequence with empty line");

            line = Console.ReadLine();
            while (line != string.Empty)
            {
                sequence.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            List<int> onlyPositives = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] > 0)
                {
                    onlyPositives.Add(sequence[i]);
                }
            }

            foreach (var item in onlyPositives)
            {
                Console.WriteLine(item);
            }
        }
    }
}
