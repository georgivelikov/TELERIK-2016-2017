namespace Cosmetics.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Tests.Engine.Mocks;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CommandEngineTests
    {
        [Test]
        public void Start_CreateCategoryCommandWithValidInput_ShouldCreateNewCategoryAndAddItToCollectionOfCategories()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedCreateCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedCreateCommand.Object });
            mockedCreateCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCreateCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { "ForMale" });
            mockedFactory.Setup(x => x.CreateCategory("ForMale")).Returns(() => mockedCategory.Object);
            
            mockedEngine.Start();

            Assert.IsTrue(mockedEngine.Categories.ContainsKey("ForMale"));
            Assert.AreSame(mockedCategory.Object, mockedEngine.Categories["ForMale"]);
        }

        [Test]
        public void Start_AddToCategoryWithValidInput_ShoudInvokeAddProductMethodOfCategory()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedAddToCategoryCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedAddToCategoryCommand.Object });
            mockedAddToCategoryCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            mockedAddToCategoryCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { "ForMale", "Cool" });
            mockedCategory.SetupGet(x => x.Name).Returns("ForMale");
            mockedProduct.SetupGet(x => x.Name).Returns("Cool");
            
            mockedEngine.Categories.Add("ForMale", mockedCategory.Object);
            mockedEngine.Products.Add("Cool", mockedProduct.Object);
            mockedEngine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_RemoveFromCategoryWithValidInput_ShoudInvokeRemoveProductMethodOfCategory()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedRemoveFromCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedRemoveFromCommand.Object });
            mockedRemoveFromCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            mockedRemoveFromCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { "ForMale", "Cool" });
            mockedCategory.SetupGet(x => x.Name).Returns("ForMale");
            mockedProduct.SetupGet(x => x.Name).Returns("Cool");

            mockedEngine.Categories.Add("ForMale", mockedCategory.Object);
            mockedEngine.Products.Add("Cool", mockedProduct.Object);
            mockedEngine.Start();

            mockedCategory.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_ShowCommandWithValidInput_ShouldInvokePrintMethodOfCategory()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            var mockedShowCategoryCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(() => new List<ICommand>() { mockedShowCategoryCommand.Object });
            mockedShowCategoryCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            mockedShowCategoryCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { "ForMale"});
            mockedCategory.SetupGet(x => x.Name).Returns("ForMale");

            mockedEngine.Categories.Add("ForMale", mockedCategory.Object);
            mockedEngine.Start();

            mockedCategory.Verify(x => x.Print(), Times.Once);
        }
    }
}
