namespace IntergalacticTravel.Tests.TeleportStation
{
    using System;
    using System.Collections.Generic;

    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Exceptions;
    using IntergalacticTravel.Tests.TeleportStationTests.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using NUnit.Framework;

    using Assert = NUnit.Framework.Assert;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void ConstructorWithValidParameters_ShouldSetOwnerFieldCorrect_WhenTeleportSystemIsInitiated()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            Assert.IsInstanceOf<ITeleportStation>(teleportStation);
            Assert.AreSame(teleportStation.Owner, mockedOwner.Object);
        }

        [Test]
        public void ConstructorWithValidParameters_ShouldSetGalacticMapFieldCorrect_WhenTeleportSystemIsInitiated()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            Assert.IsInstanceOf<ITeleportStation>(teleportStation);
            Assert.AreSame(teleportStation.GalacticMap, mockedList);
        }

        [Test]
        public void ConstructorWithValidParameters_ShouldSetLocationFieldCorrect_WhenTeleportSystemIsInitiated()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            Assert.IsInstanceOf<ITeleportStation>(teleportStation);
            Assert.AreSame(teleportStation.Location, mockedLocation.Object);
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenUnitToTeleportIsNull()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedDestination = new Mock<ILocation>();

            Assert.That(() => teleportStation.TeleportUnit(null, mockedDestination.Object), Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenDestinationLacationIsNull()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();

            Assert.That(() => teleportStation.TeleportUnit(mockedUnit.Object, null), Throws.ArgumentNullException.With.Message.Contains("destination"));
        }

        [Test]
        public void TeleportUnit_ShouldThrowTeleportOutOfRangeExceptionWithCorrectMessage_WhenTryingToUseTheTeleportFromADistantLocation()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var ex = Assert.Throws<TeleportOutOfRangeException>(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));
            Assert.True(ex.Message.Contains("unitToTeleport.CurrentLocation"));
        }

        [Test]
        public void TeleportUnit_ShouldThrowInvalidTeleportationLocationExceptionWithCorrectMessage_WhenTryingToTeleportToALocationThatIsAlreadyTaken()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            
            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var mockedUnitCoordinate = new Mock<IGPSCoordinates>();
            mockedUnitCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            mockedUnitCoordinate.SetupGet(x => x.Longtitude).Returns(2000);
            mockedOccupiedUnitLocation.SetupGet(x => x.Coordinates).Returns(mockedUnitCoordinate.Object);
            
            var destinationCoordinate = new Mock<IGPSCoordinates>();
            destinationCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            destinationCoordinate.SetupGet(x => x.Longtitude).Returns(2000);
            mockedDestination.SetupGet(x => x.Coordinates).Returns(destinationCoordinate.Object);

            var ex = Assert.Throws<InvalidTeleportationLocationException>(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));
            Assert.True(ex.Message.Contains("units will overlap"));
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithCorrectMessage_WhenTryingToTeleportToToInvalidGalaxy()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            var mockedDestinationGalaxy = new Mock<IGalaxy>();
            mockedDestinationGalaxy.SetupGet(x => x.Name).Returns("XXXXXx");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedDestinationGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocation.Object);

            var ex = Assert.Throws<LocationNotFoundException>(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));
            Assert.True(ex.Message.Contains("Galaxy"));
        }

        [Test]
        public void TeleportUnit_ShouldThrowLocationNotFoundExceptionWithCorrectMessage_WhenTryingToTeleportToInvalidPlanet()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            var mockedDestinationGalaxy = new Mock<IGalaxy>();
            mockedDestinationGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedDestinationGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocation.Object);


            var ex = Assert.Throws<LocationNotFoundException>(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));
            Assert.True(ex.Message.Contains("Planet"));
        }

        [Test]
        public void TeleportUnit_ShouldInsufficientResourcesExceptionWithCorrectMessage_WhenNotEnoughResources()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            var mockedDestinationGalaxy = new Mock<IGalaxy>();
            mockedDestinationGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedDestinationGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var mockedUnitCoordinate = new Mock<IGPSCoordinates>();
            mockedUnitCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            mockedUnitCoordinate.SetupGet(x => x.Longtitude).Returns(2000);
            mockedOccupiedUnitLocation.SetupGet(x => x.Coordinates).Returns(mockedUnitCoordinate.Object);

            var destinationCoordinate = new Mock<IGPSCoordinates>();
            destinationCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            destinationCoordinate.SetupGet(x => x.Longtitude).Returns(5000);
            mockedDestination.SetupGet(x => x.Coordinates).Returns(destinationCoordinate.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);
            var ex = Assert.Throws<InsufficientResourcesException>(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object));
            Assert.True(ex.Message.Contains("FREE LUNCH"));
        }

        [Test]
        public void TeleportUnit_ShouldInvokeGetPayment_WhenEnoughResources()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            var mockedDestinationGalaxy = new Mock<IGalaxy>();
            mockedDestinationGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedDestinationGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var mockedUnitCoordinate = new Mock<IGPSCoordinates>();
            mockedUnitCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            mockedUnitCoordinate.SetupGet(x => x.Longtitude).Returns(2000);
            mockedOccupiedUnitLocation.SetupGet(x => x.Coordinates).Returns(mockedUnitCoordinate.Object);

            var destinationCoordinate = new Mock<IGPSCoordinates>();
            destinationCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            destinationCoordinate.SetupGet(x => x.Longtitude).Returns(5000);
            mockedDestination.SetupGet(x => x.Coordinates).Returns(destinationCoordinate.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            mockedPath.SetupGet(x => x.Cost).Returns(new Resources(100, 100, 100));

            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);
            mockedPath.Verify(x => x.Cost, Times.Once);

        }

        [Test]
        public void TeleportUnit_ShouldObtainPaymentFromUni_WhenAllValidationPassed()
        {
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedPath = new Mock<IPath>();
            var mockedList = new List<IPath> { mockedPath.Object };

            var teleportStation = new MockedTeleportStation(mockedOwner.Object, mockedList, mockedLocation.Object);

            var mockedUnit = new Mock<IUnit>();
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");

            var mockedPlanet = new Mock<IPlanet>();
            mockedPlanet.SetupGet(x => x.Name).Returns("Earth");
            mockedPlanet.SetupGet(x => x.Galaxy).Returns(mockedGalaxy.Object);

            mockedLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);
            mockedUnitLocation.SetupGet(x => x.Planet).Returns(mockedPlanet.Object);

            var mockedDestination = new Mock<ILocation>();
            var mockedDestinationPlanet = new Mock<IPlanet>();
            var mockedDestinationGalaxy = new Mock<IGalaxy>();
            mockedDestinationGalaxy.SetupGet(x => x.Name).Returns("MilkyWay");
            mockedDestinationPlanet.SetupGet(x => x.Name).Returns("Mars");
            mockedDestinationPlanet.SetupGet(x => x.Galaxy).Returns(mockedDestinationGalaxy.Object);
            mockedDestination.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);

            var mockedOccupiedUnit = new Mock<IUnit>();
            var mockedOccupiedUnitLocation = new Mock<ILocation>();
            mockedOccupiedUnitLocation.SetupGet(x => x.Planet).Returns(mockedDestinationPlanet.Object);
            mockedOccupiedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedOccupiedUnitLocation.Object);

            var destinationPlanetListOfUnits = new List<IUnit>() { mockedOccupiedUnit.Object };
            mockedDestinationPlanet.SetupGet(x => x.Units).Returns(destinationPlanetListOfUnits);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedDestination.Object);

            var mockedUnitCoordinate = new Mock<IGPSCoordinates>();
            mockedUnitCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            mockedUnitCoordinate.SetupGet(x => x.Longtitude).Returns(2000);
            mockedOccupiedUnitLocation.SetupGet(x => x.Coordinates).Returns(mockedUnitCoordinate.Object);

            var destinationCoordinate = new Mock<IGPSCoordinates>();
            destinationCoordinate.SetupGet(x => x.Latitude).Returns(1000);
            destinationCoordinate.SetupGet(x => x.Longtitude).Returns(5000);
            mockedDestination.SetupGet(x => x.Coordinates).Returns(destinationCoordinate.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            mockedPath.SetupGet(x => x.Cost).Returns(new Resources(100, 100, 100));
            var mockedResource = new Mock<IResources>();
            mockedResource.SetupGet(x => x.GoldCoins).Returns(200);
            mockedResource.SetupGet(x => x.SilverCoins).Returns(200);
            mockedResource.SetupGet(x => x.BronzeCoins).Returns(200);
            teleportStation.TeleportUnit(mockedUnit.Object, mockedDestination.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(It.IsAny<IResources>()).Verifiable();
            mockedUnit.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }
    }
}
