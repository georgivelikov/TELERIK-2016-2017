namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
            // : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
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

            Assert.AreEqual(5, model.Count);
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
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // HOMEWORK TESTS
        [TestMethod]
        public void SearchingCarShouldReturnCorrectIfTheRightConditionIsPassed()
        {
            string condition = "Whatever";

            var listOfCars = (ICollection<Car>)this.GetModel(() => this.controller.Search(condition));

            var expected = 2; // controller.Search is set to search for BMWs, there are 2 in the fake data
            var actual = listOfCars.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchingCarShouldReturnTheWholeCollectionWhenConditionIsNullOrEmpty()
        {
            string condition = "";

            var listOfCars = (ICollection<Car>)this.GetModel(() => this.controller.Search(condition));

            var expected = 5; // From PopulateFakeDateMethod() the count of all cars in the collection
            var actual = listOfCars.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortedByMakeShouldReturnSortedCollectionOfCars()
        {
            string condition = "make";

            var listOfCars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(condition));

            var expected = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 5, Make = "Audi", Model = "A5", Year = 2002 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
            var actual = listOfCars.ToList();

            CollectionAssert.AreEqual(expected, actual); // override Car.Equals() method
        }

        [TestMethod]
        public void SortedByYearShouldReturnSortedCollectionOfCars()
        {
            string condition = "year";

            var listOfCars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(condition));

            var expected = new List<Car>
            {
                new Car { Id = 5, Make = "Audi", Model = "A5", Year = 2002 },
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },  
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
            var actual = listOfCars.ToList();

            CollectionAssert.AreEqual(expected, actual); // override Car.Equals() method
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortedShouldThrowExceptionWhenInvalidParameterIsPassed()
        {
            string condition = "some parameter other than make or year";

            var listOfCars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(condition));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsShouldThrowExceptionWhenCarWithTheIdPassedIsNotInTheData()
        {
            int id = -1;

            var car = (Car)this.GetModel(() => this.controller.Details(id));

        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
