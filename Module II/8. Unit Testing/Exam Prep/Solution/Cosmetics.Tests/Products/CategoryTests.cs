using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cosmetics.Tests.Products
{
    using System.Text;

    using Cosmetics.Products;

    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Print_ShouldReturnStringInTheCorrectFormat()
        {
            var categoryName = "For Male";
            var category = new Category(categoryName);

            var sb = new StringBuilder();
            sb.AppendFormat(
                string.Format("{0} category - {1} {2} in total", categoryName, 0, "products"));
            var expected = sb.ToString();
            var actual = category.Print();

            Assert.AreEqual(expected, actual);


        }
    }
}
