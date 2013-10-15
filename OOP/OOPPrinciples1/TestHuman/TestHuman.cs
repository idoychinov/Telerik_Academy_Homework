using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Human;

namespace TestHuman
{
    [TestClass]
    public class TestHuman
    {
        List<Student> students;
        List<Worker> workers;

        [TestInitialize]
        public void TestInitialize()
        {
            students = new List<Student>()
            {
                new Student("Petur", "Georgiev", 2),
                new Student("Mariq", "Nikolova", 4),
                new Student("Hristo", "Petrov", 6),
                new Student("Dimitur", "Apostolov", 3),
                new Student("Asq", "Gencheva", 5),
                new Student("Kaloqn", "Spasov", 5),
                new Student("Metodi", "Jelev", 2),
                new Student("Gergana", "Dimitrova", 6),
                new Student("Mincho", "Minchev", 4),
                new Student("Asen", "Hristov", 3)
            };

            workers = new List<Worker>()
            {
                new Worker ("Gaco", "Bacov",200,8),  // money per hour 5
                new Worker ("Petq", "Asenova",400,8),  // money per hour 10
                new Worker ("Asen", "Kirilov",500,10),  // money per hour 10
                new Worker ("Haralampi", "Petkov",600,8),  // money per hour 15
                new Worker ("Minka", "Boqnova",180,6),  // money per hour 6
                new Worker ("Boqn", "Minchev",245,7),  // money per hour 7
                new Worker ("Mariqn", "Raikov",60,4),  // money per hour 3
                new Worker ("Elena", "Georgieva",585,9),  // money per hour 13
                new Worker ("Kalin", "Kirov",1000,10),  // money per hour 20
                new Worker ("Pancho", "Panchev",405,9),  // money per hour 9
            };
        }

        [TestMethod]
        public void OrderStudents()
        {
            List<Student> orderedStudentList = students.OrderBy(s => s.Grade).ToList<Student>();
            bool condition = orderedStudentList[0].Grade == 2 && orderedStudentList[9].Grade == 6;
            Assert.IsTrue(condition , "The list is not sorted correctly");
        }

        [TestMethod]
        public void OrderWorkers()
        {
            List<Worker> orderedWorkerList = workers.OrderByDescending(s => s.MoneyPerHour()).ToList<Worker>();
            bool condition = orderedWorkerList[0].MoneyPerHour() == 20 && orderedWorkerList[9].MoneyPerHour() == 3;
            Assert.IsTrue(condition, "The list is not sorted correctly");
        }

        [TestMethod]
        public void MergeLists()
        {
            List<Human.Human>  mergedList = new List<Human.Human>();
            foreach (var student in students)
            {
                mergedList.Add(student);
            }

            foreach (var worker in workers)
            {
                mergedList.Add(worker);
            }

            mergedList = mergedList.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();
            bool condition = mergedList[0].FirstName == "Asen" && mergedList[0].LastName == "Hristov" && mergedList[19].FirstName == "Petur" && mergedList[19].LastName == "Georgiev";
            Assert.IsTrue(condition, "The list is not sorted correctly");
        }
    }
}
