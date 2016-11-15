using Dealership.Application;
using Dealership.Factories;
using Dealership.Models;

using Ninject;

using NUnit.Framework;

namespace Dealership.Tests
{
    [TestFixture]
    public class Tests
    {
        private IKernel kernel;

        public Tests()
        {
            this.kernel = new StandardKernel(new DealershipModule());
        }

        [Test]
        public void TestFactoryShouldReturnCar()
        {
            var factory = this.kernel.Get<IModelFactory>();

            var car = factory.GetCar("aaa", "bbb", 10, 5);

            Assert.IsInstanceOf<Car>(car);
        }

        [Test]
        public void TestFactoryShouldReturnMotorcycle()
        {
            this.kernel = new StandardKernel(new DealershipModule());

            var factory = this.kernel.Get<IModelFactory>();

            var motor = factory.GetMotorcycle("aaa", "bbb", 10, "asda");

            Assert.IsInstanceOf<Motorcycle>(motor);
        }
    }
}
