using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.Tests.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Products;

    using NUnit.Framework;

    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    public class ToothpasteTests
    {
        [Test]
        public void Print_ShouldReturnStringInCorrectFormat()
        {
            var name = "Male";
            var brand = "Brand";
            var price = 10m;
            var ingredients = new List<string> { "aaaaa", "bbbbb"};

            var shampoo = new Toothpaste(name, brand, 10m, GenderType.Men, ingredients);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0} - {1}:", brand, name));
            sb.AppendLine(string.Format("  * Price: ${0}", price));
            sb.AppendLine(string.Format("  * For gender: {0}", GenderType.Men));
            sb.Append(string.Format("  * Ingredients: {0}", string.Join(", ", ingredients)));

            var expected = sb.ToString();
            var actual = shampoo.Print();

            NUnit.Framework.Assert.AreEqual(expected, actual);
        }
    }
}
