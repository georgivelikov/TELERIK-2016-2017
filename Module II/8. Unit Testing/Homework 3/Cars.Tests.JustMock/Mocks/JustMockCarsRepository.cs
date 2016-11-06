namespace Cars.Tests.JustMock.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            // ADDED FOR THE HOMEWORK
            Mock.Arrange(() => this.CarsData.GetById(-1)).Returns(this.FakeCarCollection.FirstOrDefault(c => c.Id == 1000));
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange(0, int.MaxValue, RangeKind.Inclusive))).Returns(this.FakeCarCollection.First());
            Mock.Arrange(() => this.CarsData.Search(Arg.NullOrEmpty)).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
        }
    }
}
