namespace Cosmetics.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;
    using Cosmetics.Products;

    using NUnit.Framework;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string invalidName)
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(invalidName, "Brand", 10m, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("s")]
        [TestCase("too long name long long")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenNameParameterIsWithInvalidLength(string invalidName)
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(invalidName, "Brand", 10m, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_ShouldThrowNullReferenceException_WhenBrandParameterIsNullOrEmpty(string invalidBrand)
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("Name", invalidBrand, 10m, GenderType.Men, 100, UsageType.EveryDay));
        }

        [TestCase("s")]
        [TestCase("too long brand long long")]
        public void CreateShampoo_ShouldThrowIndexOutOfRangeException_WhenBrandParameterIsWithInvalidLength(string invalidBrand)
        {
            var factory = new CosmeticsFactory();
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("Name", invalidBrand, 10m, GenderType.Men, 100, UsageType.EveryDay));
        }

        [Test]
        public void CreateShampoo_ShouldReturnNewShampoo_WhenAllParamteresAreValid()
        {
            string validName = "Name";
            string validBrand = "Brand";
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo(validName, validBrand, 10m, GenderType.Men, 100, UsageType.EveryDay);

            Assert.IsInstanceOf<IShampoo>(shampoo);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string invalidName)
        {
            var factory = new CosmeticsFactory();
            string validBrand = "Brand";
            var validIngredients = new List<string> { "aaaaa", "bbbbb" };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(invalidName, validBrand, 5m, GenderType.Men, validIngredients));
        }

        [TestCase("s")]
        [TestCase("too long name long long")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenNameParameterIsWithInvalidLength(string invalidName)
        {
            var factory = new CosmeticsFactory();
            string validBrand = "Brand";
            var validIngredients = new List<string> { "aaaaa", "bbbbb" };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(invalidName, validBrand, 5m, GenderType.Men, validIngredients));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_ShouldThrowNullReferenceException_WhenBrandParameterIsNullOrEmpty(string invalidBrand)
        {
            var factory = new CosmeticsFactory();
            string validName = "Name";
            var validIngredients = new List<string> { "aaaaa", "bbbbb" };

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(validName, invalidBrand, 5m, GenderType.Men, validIngredients));
        }

        [TestCase("s")]
        [TestCase("too long brand long long")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenBrandParameterIsWithInvalidLength(string invalidBrand)
        {
            var factory = new CosmeticsFactory();
            string validName = "Name";
            var validIngredients = new List<string> { "aaaaa", "bbbbb" };

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(validName, invalidBrand, 5m, GenderType.Men, validIngredients));
        }

        [TestCase("valid ing", "too long ingredient is too long")]
        [TestCase("ing", "valid ing")]
        public void CreateToothpaste_ShouldThrowIndexOutOfRangeException_WhenAnyOfTheIngredientsIsWithInvalidLength(params string[] invalidList)
        {
            string validName = "Name";
            string validBrand = "Brand";
            var invalidListOfIngredients = invalidList.ToList();
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(validName, validBrand, 5m, GenderType.Men, invalidListOfIngredients));
        }

        [Test]
        public void CreateShoppingCart_ShouldReturnInstanceOfShoppingCart_WhenAllParamteresAreValid()
        {
            var factory = new CosmeticsFactory();

            var shoppingCart = factory.CreateShoppingCart();

            Assert.IsInstanceOf<IShoppingCart>(shoppingCart);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_ShouldThrowNullReferenceException_WhenNameParameterIsNullOrEmpty(string invalidName)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(invalidName));
        }

        [TestCase("s")]
        [TestCase("too long name long long")]
        public void CreateCategory_ShouldThrowIndexOutOfRangeException_WhenNameParameterIsWithInvalidLength(string invalidName)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(invalidName));
        }

        [Test]
        public void CreateCategory_ShouldReturnInstanceOfCategory_WhenAllParamteresAreValid()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateCategory("validName");

            Assert.IsInstanceOf<ICategory>(category);
        }
    }
}
