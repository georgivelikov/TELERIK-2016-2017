namespace Cosmetics.Tests
{
    using System;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Products;

    using NUnit.Framework;

    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void Print_ShouldReturnStringInCorrectFormat()
        {
            var name = "Male";
            var brand = "Brand";
            var price = 10m;
            var milliliters = 100;

            var shampoo = new Shampoo(name, brand, 10m, GenderType.Men, 100, UsageType.EveryDay);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0} - {1}:", brand, name));
            sb.AppendLine(string.Format("  * Price: ${0}", price * milliliters));
            sb.AppendLine(string.Format("  * For gender: {0}", GenderType.Men));
            sb.AppendLine(string.Format("  * Quantity: {0} ml", milliliters));
            sb.Append(string.Format("  * Usage: {0}", UsageType.EveryDay));

            var expected = sb.ToString();
            var actual = shampoo.Print();

            Assert.AreEqual(expected, actual);
        }

    }
}

