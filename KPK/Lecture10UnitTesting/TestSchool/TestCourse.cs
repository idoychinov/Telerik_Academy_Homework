namespace TestSchool
{
    using School;
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    /// <summary>
    /// Only ordered test of students and courses should be run and analyzed for code coverage. It contains all other tests for both
    /// Students and Courses. This is becouse of the internal static id counter of student.
    /// Code covarage 93,48
    /// </summary>
    [TestClass]
    public class TestCourse
    {
        private const string CourseName = "Test_Course123";
        private const string StudentName = "Pesho";
        private const int MaxStudentsInCourse = 30;


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseErrorIfNameIsNull()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCourseErrorIfNameIEmpty()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        public void TestCourseName()
        {
            Course course = new Course(CourseName);
            Assert.AreEqual(CourseName, course.Name, "Start Id is wrong");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseErrorAddingNullStudent()
        {
            Course course = new Course(CourseName);
            Student student = null;
            course.AddStudent(student);
        }

        [TestMethod]
        public void TestCourseStudentPropertyReturnsNewList()
        {
            Course course = new Course(CourseName);
            Student student = new Student(StudentName);
            var studentID = student.Id;
            course.AddStudent(student);
            IList<Student> listoOfStudents = course.Students;
            listoOfStudents.Clear();
            Assert.AreEqual(1, course.Students.Count, "Student property has not returnd new list");
        }

        [TestMethod]
        public void TestCourseStudentPropertyGivesAccessToStudents()
        {
            Course course = new Course(CourseName);
            Student student = new Student(StudentName);
            var studentID = student.Id;
            course.AddStudent(student);
            Assert.AreEqual(studentID, course.Students[0].Id, "Student property returns list with new students istead of existing students");
        }

        [TestMethod]
        public void TestCourseAddNewStudent()
        {
            Course course = new Course(CourseName);
            Student student = new Student(StudentName);
            course.AddStudent(student);
            Assert.AreEqual(student, course.Students[0], "Student has not been added to the course");
        }

        [TestMethod]
        public void TestCourseRemoveExistingStudent()
        {
            Course course = new Course(CourseName);
            Student student = new Student(StudentName);
            var studentID = student.Id;
            course.AddStudent(student);
            course.RemoveStudent(studentID);
            Assert.AreEqual(0, course.Students.Count, "Student has not been removed");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseErrorRemoveNonExistingStudent()
        {
            Course course = new Course(CourseName);
            Student student = new Student(StudentName);
            var studentID = student.Id;
            course.RemoveStudent(studentID + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseMaxNumberOfStudents()
        {
            Course course = new Course(CourseName);
            for (int i = 0; i < MaxStudentsInCourse; i++)
            {
                course.AddStudent(new Student(StudentName + i));
            }
            Assert.AreEqual(MaxStudentsInCourse,course.Students.Count,"Students in course have not reached maximum value");
            course.AddStudent(new Student(StudentName +MaxStudentsInCourse));
        }


    }
}
