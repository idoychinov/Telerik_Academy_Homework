using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;
using System.Collections.Generic;

namespace TestSchool
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestComment()
        {
            const string comment = "test comment";
            Teacher teacher = new Teacher("Pesho", new List<Discipline>());
            teacher.OptionalComment = comment;
            Assert.AreEqual(comment, teacher.OptionalComment, "Comment is not recorded or displayed properly");

        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException),"Duplicate class ID")]
        public void TestIfDuplicateStudentIDsThrowException()
        {
            Student studentA = new Student("Pesho", 234);
            Student studentB = new Student("Gosho", 234);
        }
    }
}
