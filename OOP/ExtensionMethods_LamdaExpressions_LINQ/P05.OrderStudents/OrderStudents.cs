using System;
using System.Linq;

// Problem 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
// Rewrite the same with LINQ.


namespace P05.OrderStudents
{
    class OrderStudents
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

            // Lambda expressions implementation

            Console.WriteLine("Lambda expressions implementation");
            var subset = studentArray.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);

            foreach (var student in subset)
            {
                Console.WriteLine("{0} {1}, Age {2}", student.FirstName, student.LastName, student.Age);
            }

            //LINQ implementation

            Console.WriteLine("\n\nLINQ implementation");
            var query =
                from s in studentArray                
                orderby s.FirstName,s.LastName
                select s;

            foreach (var student in query)
            {
                Console.WriteLine("{0} {1}, Age {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
