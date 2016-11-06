namespace IntergalacticTravel.Tests.BussinessOwnerTests
{
    using System;
    using System.Collections.Generic;

    using IntergalacticTravel.Contracts;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldIncreaseOwnerResourses_ByTheTotalAmountGeneratedFromTeleportStation()
        {
            string name = "Pesho";
            int number = 1;
            var teleportStationMock = new Mock<ITeleportStation>();
            List<ITeleportStation> list = new List<ITeleportStation>();
            list.Add(teleportStationMock.Object);
            var owner = new BusinessOwner(number, name, list);

            teleportStationMock.Setup(x => x.PayProfits(owner)).Returns(new Resources(300, 200, 100));

            owner.CollectProfits();

            Assert.AreEqual(100, owner.Resources.GoldCoins);
            Assert.AreEqual(200, owner.Resources.SilverCoins);
            Assert.AreEqual(300, owner.Resources.BronzeCoins);
        }
    }
}
