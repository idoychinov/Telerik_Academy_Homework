namespace Task01BinaryPasswords
{
    using System;
    using System.Linq;
 
    class Task01BinaryPasswords
    {
        static void Main()
        {
            Console.WriteLine(1L << Console.ReadLine().Count(c => c == '*'));
        }
    }
}
