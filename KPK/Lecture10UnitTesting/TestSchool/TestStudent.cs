namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    /// <summary>
    /// Using ordered test because of the static internal counter. If all the test methods are selected and run the static context will
    /// remain active and the test need to be run in the selected order to prevent the counter going out of range prematurly.
    /// Code covarege for Student is 100%
    /// </summary>
    [TestClass]
    public class TestStudent
    {
        private const int StartID = 10000;
        private const int EndID = 99999;
        private const string StudentName = "Test@Student1";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentErrorIfNameIsNull()
        {
            Student student = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentErrorIfNameIEmpty()
        {
            Student student = new Student(string.Empty);
        }

        [TestMethod]
        public void TestStudentName()
        {
            Student student = new Student(StudentName);
            Assert.AreEqual(StudentName, student.Name, "Start Id is wrong");
        }

        [TestMethod]
        public void TestStudentStartId()
        {
            Student student = new Student("test");
            Assert.AreEqual(StartID, student.Id, "Start Id is wrong");
        }

        [TestMethod]
        public void TestStudenIdAutoIncrement()
        {
            Student student = new Student("test");
            var currentID = student.Id;
            student = new Student("test2");
            Assert.AreEqual(currentID + 1, student.Id, "Start Id is wrong");
        }

        [TestMethod]
        public void TestStudenIdMax()
        {
            Student student = new Student("test");
            var currentID = student.Id;
            for (int i = currentID; i < EndID; i++)
            {
                student = new Student("test");
            }

            Assert.AreEqual(EndID, student.Id, "End Id is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentErrorIfAllIdsAreUsed()
        {
            Student student = new Student("test");
            var currentID = student.Id;
            for (int i = currentID; i < EndID + 1; i++)
            {
                student = new Student("test");
            }
        }
    }
}
