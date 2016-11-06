namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResource_ShouldCreateInstaceOfResourcesObjectWithCorrectGoldProperty_WhenInputStringIsInCorrectFormat(string commandString)
        {
            var factory = new ResourcesFactory();

            var resourcesObject = factory.GetResources(commandString);

            var expectedGoldProp = 20;
            
            Assert.IsInstanceOf<Resources>(resourcesObject);
            Assert.AreEqual(resourcesObject.GoldCoins, expectedGoldProp);
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResource_ShouldCreateInstaceOfResourcesObjectWithCorrectSilverProperty_WhenInputStringIsInCorrectFormat(string commandString)
        {
            var factory = new ResourcesFactory();

            var resourcesObject = factory.GetResources(commandString);

            var expectedSilverProp = 30;

            Assert.IsInstanceOf<Resources>(resourcesObject);
            Assert.AreEqual(resourcesObject.SilverCoins, expectedSilverProp);
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResource_ShouldCreateInstaceOfResourcesObjectWithCorrectBronzeProperty_WhenInputStringIsInCorrectFormat(string commandString)
        {
            var factory = new ResourcesFactory();

            var resourcesObject = factory.GetResources(commandString);

            var expectedBronzeProp = 40;

            Assert.IsInstanceOf<Resources>(resourcesObject);
            Assert.AreEqual(resourcesObject.BronzeCoins, expectedBronzeProp);
        }

        [TestCase("create resources x y z")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResource_ShouldThrowInvalidOperationException_WhenInputStringIsInvalid(string commandString)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<InvalidOperationException>(() => factory.GetResources(commandString));
        }

        [TestCase("create resources gold(20) silver(300000000787800) bronze(40)")]
        [TestCase("create resources gold(20) silver(30) bronze(4009677900000)")]
        public void GetResource_ShouldThrowOverflowException_WhenInputValueIsLargerThanUintMaxValueOrSmallerThanUnitMinValue(string commandString)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(commandString));
        }
    }
}
