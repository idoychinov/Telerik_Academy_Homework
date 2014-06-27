namespace Task03ListSort
{
    using System;
    using System.Collections.Generic;

    public class Task03ListSort
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

            sequence.Sort();

            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
