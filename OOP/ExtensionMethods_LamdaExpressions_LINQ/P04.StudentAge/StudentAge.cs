using System;
using System.Linq;

// Problem 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

namespace P04.StudentAge
{
    class StudentAge
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
                where s.Age>=18  && s.Age<=24
                select s;

            foreach (var student in query)
            {
                Console.WriteLine("{0} {1}, Age {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
