namespace Cosmetics.Tests
{
    using System;

    using Cosmetics.Common;
    using Cosmetics.Products;

    using NUnit.Framework;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_ShouldThrowNullReferenceException_WhenParameterIsNull()
        {
            object testObject = null;
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(testObject));
        }

        [Test]
        public void CheckIfNull_ShouldNotThrowNullReferenceException_WhenParameterIsValid()
        {
            object testObject = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(testObject));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenParameterIsNullOrEmpty(string text)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("validText")]
        public void CheckIfStringIsNullOrEmpty_ShouldNotThrowNullReferenceException_WhenParameterIsValid(string text)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase("VeryLongInvalidTextLongLongLong", 15, 7)]
        [TestCase("short", 15, 7)]
        [TestCase("borderCaseLong", 13, 7)]
        [TestCase("borderCaseShort", 25, 16)]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_WhenParameterIsIsWithInvalidLength(string text, int max, int min)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [TestCase("validText", 15, 7)]
        [TestCase("alsoValidText", 25, 10)]
        public void CheckIfStringLengthIsValid_ShouldNotThrowIndexOutOfRangeException_WhenParameterIsWithValidLength(string text, int max, int min)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
