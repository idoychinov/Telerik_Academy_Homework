using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPerson
{
    [TestClass]
    public class TestPerson
    {
        [TestMethod]
        public void TestPersonWithUnspecifiedAge()
        {
            Person.Person person = new Person.Person("Gosho");
            string expectedResult ="Name: Gosho\r\nAge: Unspecified\r\n";
            Assert.AreEqual(expectedResult,person.ToString(),"Incorect result from ToString() when age is unspecified");
        }

        [TestMethod]
        public void TestPersonWithSpecifiedAge()
        {
            Person.Person person = new Person.Person("Gosho",27);
            string expectedResult = "Name: Gosho\r\nAge: 27\r\n";
            Assert.AreEqual(expectedResult, person.ToString(), "Incorect result from ToString() when age is unspecified");
        }
    }
}
