namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // New Tests added below

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByInvalidParameterShouldThrowException()
        {
            this.controller.Sort("Make");
        }

        [TestMethod]
        public void SoryByMakeShouldReturnSortedCollectionByMake()
        {
            string[] sortedMakes = new string[4] {
                "Audi", 
                "BMW", 
                "BMW", 
                "Opel"
            };
            var sortedOutputColection = (ICollection<Car>)this.GetModel(() =>this.controller.Sort("make"));
                
            var count = 0;
            foreach (var item in sortedOutputColection)
            {
                Assert.AreEqual(sortedMakes[count], item.Make, "Incorect Make ordering");
                count++;
            }
        }

        [TestMethod]
        public void SoryByYearShouldReturnSortedCollectionByYearDescending()
        {
            int[] sortedYars = new int[4] {
                2010,
                2008,
                2007,
                2005
            };
            var sortedOutputColection = (ICollection<Car>)this.GetModel(() =>this.controller.Sort("year"));

            var count = 0;
            foreach (var item in sortedOutputColection)
            {
                Assert.AreEqual(sortedYars[count], item.Year, "Incorect Make ordering");
                count++;
            }
        }

        [TestMethod]
        public void SearchByEmptyConditionShouldReturnTheWholeCollection()
        {
            var wholeColection = (ICollection<Car>)this.GetModel(() =>this.controller.Search(""));
            Assert.AreEqual(4, wholeColection.Count);
        }

        [TestMethod]
        public void SearchByConditionInMakeShouldReturnAppropriateCollection()
        {
            var collection = (ICollection<Car>)this.GetModel(() =>this.controller.Search("BMW"));
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void SearchByConditionInModelShouldReturnAppropriateCar()
        {
            var collection = (ICollection<Car>)this.GetModel(() =>this.controller.Search("Astra"));
            Assert.AreEqual("Astra", collection.First<Car>().Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDetailByInvalidIDShouldThrowExeption()
        {
            this.controller.Details(-1);
        }


        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
