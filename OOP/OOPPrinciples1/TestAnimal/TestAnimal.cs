using System;
using System.Collections.Generic;
using Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestAnimal
{
    [TestClass]
    public class TestAnimal
    {
        List<Animal> animalList = new List<Animal>();

        [TestInitialize]
        public void TestInitialize()
        {
            animalList.Add(new Cat(4, "Mac1", AnimalSex.Male));
            animalList.Add(new Cat(7, "Mac2", AnimalSex.Male));
            animalList.Add(new Cat(5, "Mac3", AnimalSex.Male));
            animalList.Add(new Cat(9, "Mac4", AnimalSex.Male));   // Average cats age  = 6.25
            animalList.Add(new Kitten(3, "Pis1"));               // Average kitten age
            animalList.Add(new Kitten(7, "Pis2"));
            animalList.Add(new Kitten(11, "Pi3"));               // Average kitten age = 7
            animalList.Add(new Dog(5, "Bau1", AnimalSex.Male));
            animalList.Add(new Dog(2, "Bau2", AnimalSex.Male));
            animalList.Add(new Dog(3, "Bau4", AnimalSex.Male));  // Average dog age = 3.(3)
        }

        [TestMethod]
        public void TestCat()
        {
            TestAverageAgeCalculation(new AnimalGroup("Cat",6.25));
        }

        [TestMethod]
        public void TestKitten()
        {
            TestAverageAgeCalculation(new AnimalGroup("Kitten", 7));
        }

        [TestMethod]
        public void TestDog()
        {
            TestAverageAgeCalculation(new AnimalGroup("Dog", (double)10/3));
        }

        public void TestAverageAgeCalculation(AnimalGroup group)
        {
            foreach (var animalGroup in Animal.CalculateAverageAge(animalList))
            {
                if (animalGroup.GroupName == group.GroupName)
                {
                    Assert.AreEqual(group.AverageAge, animalGroup.AverageAge, "Incorect average age calculation for AnimalGroup "+group.GroupName);
                }
            }
        }
    }
}
