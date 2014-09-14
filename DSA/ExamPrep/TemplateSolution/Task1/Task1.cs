namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class Task1
    {
        private const string TestFilePath = @"..\..\test1.txt";

        static void Main()
        {
            
            if(File.Exists(TestFilePath))
            {
                Console.SetIn(new StreamReader(TestFilePath));
            }
            
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                Console.WriteLine("Line {0}: {1}", i, line);
            }
        }
    }
}
