using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Products;

    using global::Tests.Mocks;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestValidatorCheckIfNull_ThrowsNullReferenceException_WhenParameterIsNull()
        {
            Assert.Throws(typeof(NullReferenceException), () => Validator.CheckIfNull(null));
        }

        [Test]
        public void TestValidatorCheckIfNull_DoNotThrows_WhenParameterIsValid()
        {
            Shampoo shampoo = new Shampoo("Shampoo", "Brand", 12m, GenderType.Men, 9, UsageType.EveryDay);

            try
            {
                Validator.CheckIfNull(shampoo);
            }
            catch (NullReferenceException)
            {
                Assert.Fail();
            }           
        }

        [Test]
        public void TestValidatorCheckIfStringIsNullOrEmpty_ThrowsNullReferenceException_WhenTextIsNullOrEmpty()
        {
            Assert.Throws(typeof(NullReferenceException), () => Validator.CheckIfStringIsNullOrEmpty(String.Empty));
        }

        [Test]
        public void TestValidatorCheckIfStringIsNullOrEmpty_DoNotThrowsNullReferenceException_WhenTextIsNotNullOrEmpty()
        {
            var text = "Some valid text";

            try
            {
                Validator.CheckIfStringIsNullOrEmpty(text);
            }
            catch (NullReferenceException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestValidatorCheckIfLengthIsValid_ThrowsIndexOutOfException_WhenTextIsInInvalidRange()
        {
            var invalidText = "Invaliddddddd";
            var maxLen = 6;
            var minLen = 3;
            Assert.Throws(typeof(IndexOutOfRangeException), () => Validator.CheckIfStringLengthIsValid(invalidText, maxLen, minLen));
        }

        [Test]
        public void TestValidatorCheckIfLengthIsValid_DoNotThrowsIndexOutOfException_WhenTextIsInValidRange()
        {
            var validText = "Invalid";
            var maxLen = 10;
            var minLen = 3;

            try
            {
                Validator.CheckIfStringLengthIsValid(validText, maxLen, minLen);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestCommandParse_ReturnsNewCommand_WhenInputIsValidString()
        {
            var validInput = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";
            Command command = Command.Parse(validInput);

            Assert.IsNotNull(command);
        }

        [Test]
        public void TestCommandParse_ReturnsNewCommandWithCorrectName_WhenInputIsValidString()
        {
            var validInput = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";
            var expectedName = "CreateToothpaste";
            Command command = Command.Parse(validInput);
            var actualName = command.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void TestCommandParse_ReturnsNewCommandWithCorrectParameters_WhenInputIsValidString()
        {
            var validInput = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";
            var expectedParameters = "White+ Colgate 15.50 men fluor,bqla,golqma".Split();
            Command command = Command.Parse(validInput);
            var actualParameters = command.Parameters;
            
            CollectionAssert.AreEqual(expectedParameters, actualParameters);
        }

        [Test]
        public void TestCommandParse_ThrowsArgumentNullException_WhenInputIsNameIsMissing()
        {
            var invalidInput = "      CommandParameters";
            Assert.Throws(typeof(ArgumentNullException), () => Command.Parse(invalidInput));
        }

        [Test]
        public void TestCommandParse_ThrowsArgumentNullException_WhenInputIsParametersAreMissing()
        {
            var invalidInput = "CommandName        ";
            Assert.Throws(typeof(ArgumentNullException), () => Command.Parse(invalidInput));
        }

        [Test]
        public void TestEngineStart_ThrowsArgumentNullException_WhenCommandInputStringIsInvalid()
        {
            var invalidInput = "CreateCategory    ";
            Console.SetIn(new StringReader(invalidInput));
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticsEngine(factory, shoppingCart);

            Assert.Throws(typeof(ArgumentNullException), () => engine.Start());
        }

        [Test]
        public void TestEngineStart_ShoudExecuteCreateCategoryCorrect_WhenInputIsValid()
        {
            var validInput1 = "CreateCategory ForMale";
            var validInput2 = "CreateCategory ForGirls";
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            Console.SetIn(new StringReader(validInput1));
            engine.Start();

            Console.SetIn(new StringReader(validInput2));
            engine.Start();

            var actual = engine.Categories.Count;
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteAddProductToCategoryCorrect_WhenInputIsValid()
        {
            var addCommand = "AddToCategory ForMale Cool";

            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            var category = new Category("ForMale");
            var product = new Shampoo("Cool", "Nivea", 0.5m, GenderType.Men, 500, UsageType.EveryDay);
            engine.Categories.Add("ForMale", category);
            engine.Products.Add("Cool", product);

            Console.SetIn(new StringReader(addCommand));
            engine.Start();

            var privateObj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(category);
            var catProducts = (IList<IProduct>)privateObj.GetField("products");
            var actual = catProducts.Count;
            var expected = 1;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteRemoveProductFromCategoryCorrect_WhenInputIsValid()
        {
            var removeCommand = "RemoveFromCategory ForMale Cool";

            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            var category = new Category("ForMale");
            var product1 = new Shampoo("Cool", "Nivea", 0.5m, GenderType.Men, 500, UsageType.EveryDay);
            var product2 = new Shampoo("Cool2", "Nivea2", 0.5m, GenderType.Men, 500, UsageType.EveryDay);
            engine.Categories.Add("ForMale", category);
            engine.Products.Add("Cool", product1);
            engine.Products.Add("Cool2", product2);

            var privateObj = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(category);
            var categoryProducts = (IList<IProduct>)privateObj.GetField("products");

            categoryProducts.Add(product1);
            categoryProducts.Add(product2);

            Console.SetIn(new StringReader(removeCommand));
            engine.Start();

            var actual = categoryProducts.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteShowCategory_WhenInputIsValid()
        {
            var showCommand = "ShowCategory ForMale";

            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            var category = new Mock<ICategory>();
            category.Setup(c => c.Name).Returns("ForMale");
            category.Setup(c => c.Print()).Verifiable();
            engine.Categories.Add("ForMale", category.Object);
            
            Console.SetIn(new StringReader(showCommand));
            engine.Start();

            category.Verify(c => c.Print(), Times.Once);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteCreateShampooCorrect_WhenInputIsValid()
        {
            var shampooCommand = "CreateShampoo Cool Nivea 0.50 men 500 everyday";

            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            Console.SetIn(new StringReader(shampooCommand));
            engine.Start();

            var actual = engine.Products.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteCreateThoothpasteCorrect_WhenInputIsValid()
        {
            var pasteCommand = "CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma";

            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var engine = new CosmeticEngineMock(factory, shoppingCart);

            Console.SetIn(new StringReader(pasteCommand));
            engine.Start();

            var actual = engine.Products.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteAddToShoppingCorrect_WhenInputIsValid()
        {
            var addToShoppingCart = "AddToShoppingCart White+";

            var factory = new CosmeticsFactory();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticEngineMock(factory, shoppingCart.Object);
            var mockedProduct = new Mock<IProduct>();
            mockedProduct.Setup(p => p.Name).Returns("White+");
            engine.Products.Add(mockedProduct.Object.Name, mockedProduct.Object);

            shoppingCart.Setup(s => s.AddProduct(It.IsAny<IProduct>())).Verifiable();

            Console.SetIn(new StringReader(addToShoppingCart));
            engine.Start();
        
            shoppingCart.Verify(c => c.AddProduct(It.Is<IProduct>(p => p.Name == "White+")), Times.Once);
        }

        [Test]
        public void TestEngineStart_ShoudExecuteRemoveFromShoppingCorrect_WhenInputIsValid()
        {
            var removeFromShoppingCart = "RemoveFromShoppingCart White+";

            var factory = new CosmeticsFactory();
            var shoppingCart = new Mock<IShoppingCart>();
            var engine = new CosmeticEngineMock(factory, shoppingCart.Object);
            var mockedProduct = new Mock<IProduct>();
            mockedProduct.Setup(p => p.Name).Returns("White+");

            engine.Products.Add(mockedProduct.Object.Name, mockedProduct.Object);
            shoppingCart.Setup(s => s.ContainsProduct(It.IsAny<IProduct>())).Returns(true);

            shoppingCart.Setup(s => s.RemoveProduct(It.IsAny<IProduct>())).Verifiable();

            Console.SetIn(new StringReader(removeFromShoppingCart));
            engine.Start();

            shoppingCart.Verify(c => c.RemoveProduct(It.Is<IProduct>(p => p.Name == "White+")), Times.Once);
        }

        [Test]
        public void TestFactory_StringShoudThrowsReferenceNullException_WhenInputIsNullName()
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(null, "Cool", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [Test]
        public void TestFactory_StringShoudThrowsReferenceNullException_WhenInputIsEmpty()
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("", "Cool", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [Test]
        public void TestFactory_StringShoudThrowsInvalidRangeException_WhenInputNameIsWithInvalidLenght()
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("dasdasdasdasdasdas", "Cool", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [Test]
        public void TestFactory_StringShoudReturnCorrect_WhenInputIsValid()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("Cool", "Nivea", 10m, GenderType.Men, 10, UsageType.EveryDay);

            Assert.IsNotNull(shampoo);
        }
    }
}
