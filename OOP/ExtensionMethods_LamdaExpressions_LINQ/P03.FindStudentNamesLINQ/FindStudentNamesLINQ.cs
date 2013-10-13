using System;
using System.Linq;

// Problem 3. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.

namespace P03.FindStudentNamesLINQ
{
    class FindStudentNamesLINQ
    {
        static void Main()
        {
            var studentArray = new[] 
            {
                new { FirstName = "Petur", LastName = "Georgiev", Age =25 }, 
                new { FirstName = "Dimitur", LastName = "Petrov", Age =47 }, 
                new { FirstName = "Mincho", LastName = "Minchev", Age =18 }, 
                new { FirstName = "Hristo", LastName = "Nikolov", Age =28 }, 
                new { FirstName = "Pencho", LastName = "Genchev", Age =17 }, 
                new { FirstName = "Zdravko", LastName = "Apostolov", Age =21 }, 
                new { FirstName = "Iasen", LastName = "Zeliazkov", Age = 37},
                new { FirstName = "Hristo", LastName = "Genchev", Age =24 }, 
            };

            var query =
                from s in studentArray
                where s.FirstName.CompareTo(s.LastName) < 0
                select s;

            foreach (var student in query)
            {
                Console.WriteLine("{0} {1}",student.FirstName,student.LastName);
            }
        }
    }
}
