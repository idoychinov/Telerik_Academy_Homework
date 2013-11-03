using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P01to03Student;

namespace TestStudent
{
    [TestClass]
    public class TestStudent
    {
        Student studentA;
        Student studentB;

        [TestInitialize]
        public void InitStudentTests()
        {
            studentA = new Student();
            studentB = new Student();
            studentA.FirstName = "Petur";
            studentB.FirstName = "Petur";
            studentA.MiddleName = "Georgiev";
            studentB.MiddleName = "Georgiev";
            studentA.LastName = "Nikolov";
            studentB.LastName = "Nikolov";
            studentA.SSN = 32443456;
            studentB.SSN = 32443456;
            studentA.University = University.SofiaUniversity;
            studentB.University = University.SofiaUniversity;
            studentA.Specialty = Specialty.ComputerScience;
            studentB.Specialty = Specialty.ComputerScience;
            studentA.Faculty = Faculty.ComputerSystemsAndTechnologies;
            studentB.Faculty = Faculty.ComputerSystemsAndTechnologies;

            studentA.Course = "first";
            studentB.Course = "second";
        }

        [TestMethod]
        public void TestEqualityForTrue()
        {
            Assert.AreEqual(true, studentA.Equals(studentB), "Equality check failed for two equal students");
        }

        [TestMethod]
        public void TestEqualityForFalse()
        {
            studentA.SSN = 3452;
            Assert.AreEqual(false, studentA.Equals(studentB), "Equality check failed for two diferent students");
        }

        [TestMethod]
        public void TestOperatorEqualForTrue()
        {
            Assert.AreEqual(true, studentA==studentB, "Equality check == failed for two equal students");
        }

        [TestMethod]
        public void TestOpeatorEqualForFalse()
        {
            studentA.SSN = 3452;
            Assert.AreEqual(false, studentA == studentB, "Equality check == failed for two diferent students");
        }

        [TestMethod]
        public void TestOperatorNotEqualForTrue()
        {
            Assert.AreEqual(false, studentA != studentB, "Nonequality check != failed for two equal students");
        }

        [TestMethod]
        public void TestOpeatorNotEqualForFalse()
        {
            studentA.SSN = 3452;
            Assert.AreEqual(true, studentA != studentB, "Nonequality check != failed for two diferent students");
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            string studentInformation = "Student: Petur Georgiev Nikolov\r\n" +
                "SSN: 32443456\r\n" + "Address: \r\n" + "Mobile: \r\n" + "Email: \r\n" + "Course: first\r\n" +
                "University: SofiaUniversity\r\n" + "Faculty: ComputerSystemsAndTechnologies\r\n" + "Specialty: ComputerScience\r\n";
            Assert.AreEqual(studentInformation, studentA.ToString(), "ToString() doesn't produce correct string.");
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            int studentHashCode = studentA.FirstName.GetHashCode() ^ studentA.MiddleName.GetHashCode() ^ studentA.LastName.GetHashCode() ^ studentA.SSN.GetHashCode();
            Assert.AreEqual(studentHashCode, studentA.GetHashCode(), "GetHashCode() doesn't produce correct output.");
        }

        [TestMethod]
        public void TestClone()
        {
            Student ClonedStudent = new Student();
            ClonedStudent = studentA.Clone();
            Assert.AreEqual(studentA, ClonedStudent, "Student is correctly cloned");
        }

        [TestMethod]
        public void TestComparisonForGreater()
        {
            studentA.SSN = 32443457; // Increased by 1
            Assert.AreEqual(true, studentA.CompareTo(studentB)>0, "StudentA is greater than StudentB");
        }

        [TestMethod]
        public void TestComparisonForLesser()
        {
            studentA.MiddleName = "Genchev"; //Genchev is < Georgiev lexicographicly
            Assert.AreEqual(true, studentA.CompareTo(studentB) < 0, "StudentA is greater than StudentB");
        }

        [TestMethod]
        public void TestComparisonForEqual()
        {
            Assert.AreEqual(true, studentA.CompareTo(studentB) == 0, "StudentA is greater than StudentB");
        }
    }
}
