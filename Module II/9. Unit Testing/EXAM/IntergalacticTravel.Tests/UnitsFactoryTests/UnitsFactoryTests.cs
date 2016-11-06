namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    using System;

    using IntergalacticTravel.Exceptions;

    using NUnit.Framework;

    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_ShouldReturnInstanceOfProcyonUnit_WhenValidCommandIsPassed()
        {
            var factory = new UnitsFactory();
            var unit = factory.GetUnit("create unit Procyon Gosho 1");

            Assert.IsInstanceOf<Procyon>(unit);
        }

        [Test]
        public void GetUnit_ShouldReturnInstanceOfLuytenUnit_WhenValidCommandIsPassed()
        {
            var factory = new UnitsFactory();
            var unit = factory.GetUnit("create unit Luyten Gosho 1");

            Assert.IsInstanceOf<Luyten>(unit);
        }

        [Test]
        public void GetUnit_ShouldReturnInstanceOfLacailleUnit_WhenValidCommandIsPassed()
        {
            var factory = new UnitsFactory();
            var unit = factory.GetUnit("create unit Lacaille Gosho 1");

            Assert.IsInstanceOf<Lacaille>(unit);
        }

        [TestCase("create unit SomeUnit Gosho 1")]
        [TestCase("create unit Procyon 1")]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenInvalidCommandIsPassed(string commandString)
        {
            var factory = new UnitsFactory();
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(commandString));
        }
    }
}
