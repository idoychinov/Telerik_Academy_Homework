namespace Task1Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Task 1. A text file students.txt holds information about students and their courses in the following format:
    /// Kiril  | Ivanov   | C#
    /// Stefka | Nikolova | SQL
    /// Stela  | Mineva   | Java
    /// Milena | Petrova  | C#
    /// Ivan   | Grigorov | C#
    /// Ivan   | Kolev    | SQL
    /// Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:
    /// C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    /// Java: Stela Mineva
    /// SQL: Ivan Kolev, Stefka Nikolova
    /// </summary>
    public class Task1Students
    {
        public static void Main()
        {
            var courses = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            using (StreamReader reader = new StreamReader(@"../../students.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var lineParts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = lineParts[0].Trim();
                    var familyName = lineParts[1].Trim();
                    var course = lineParts[2].Trim();
                    if (courses.ContainsKey(course))
                    {
                        if (courses[course].ContainsKey(familyName))
                        {
                            courses[course][familyName].Add(name);
                        }
                        else
                        {
                            courses[course].Add(familyName, new SortedSet<string>() { name });
                        }
                    }
                    else
                    {
                        courses.Add(
                            course,
                            new SortedDictionary<string, SortedSet<string>>()
                            {
                                { familyName, new SortedSet<string>() { name } }
                            });
                    }

                    line = reader.ReadLine();
                }
            }

            foreach (var course in courses)
            {
                Console.WriteLine("Course {0}", course.Key);
                foreach (var familyName in course.Value)
                {
                    foreach (var name in familyName.Value)
                    {
                        Console.WriteLine("\t{0} {1}", name, familyName.Key);
                    }
                }
            }
        }
    }
}
