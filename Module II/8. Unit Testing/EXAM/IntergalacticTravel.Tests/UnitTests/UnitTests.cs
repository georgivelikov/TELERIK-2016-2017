namespace IntergalacticTravel.Tests.UnitTests
{
    using System;

    using IntergalacticTravel.Contracts;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_ShouldThrowNullReferenceException_WhenObjectPassedIsNull()
        {
            int number = 1;
            string name = "Ivan";

            var unit = new Unit(number, name);

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_ShouldDecreaceOwnerAmountOfResources_WithTheRecourcesPaid()
        {
            int number = 1;
            string name = "Ivan";

            var unit = new Unit(number, name);


            unit.Resources.GoldCoins = 200;
            unit.Resources.SilverCoins = 1000;
            unit.Resources.BronzeCoins = 300;

            var cost = new Resources(100, 300, 200);

            unit.Pay(cost);

            Assert.AreEqual(unit.Resources.GoldCoins, 0);
            Assert.AreEqual(unit.Resources.SilverCoins, 700);
            Assert.AreEqual(unit.Resources.BronzeCoins, 200);
        }

        [Test]
        public void Pay_ShouldReturnInstanceOfResourses_WhenInvoked()
        {
            int number = 1;
            string name = "Ivan";

            var unit = new Unit(number, name);

            unit.Resources.GoldCoins = 200;
            unit.Resources.SilverCoins = 1000;
            unit.Resources.BronzeCoins = 300;

            var cost = new Resources(100, 300, 200);
            var outcome = unit.Pay(cost);

            Assert.IsInstanceOf<IResources>(outcome);
        }
    }


}
