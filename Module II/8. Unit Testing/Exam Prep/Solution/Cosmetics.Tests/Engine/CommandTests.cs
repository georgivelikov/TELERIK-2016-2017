namespace Cosmetics.Tests
{
    using System;
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Engine;

    using NUnit.Framework;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WhenInputParamIsValid_ShouldReturnNewCommandInstance()
        {
            string input = "CreateCategory ForMale";
            var command = Command.Parse(input);

            Assert.IsInstanceOf<ICommand>(command);
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldSetCommandObjectNameCorrectly()
        {
            string input = "CreateCategory ForMale Cool";
            string name = "CreateCategory";

            var command = Command.Parse(input);

            Assert.AreEqual(name, command.Name);
        }

        [Test]
        public void Parse_WhenInputParamIsValid_ShouldSetCommandObjectParametersCorrectly()
        {
            string input = "CreateCategory ForMale Cool";
            var parameters = new List<string> { "ForMale", "Cool" };
            var command = Command.Parse(input);

            CollectionAssert.AreEqual(parameters, command.Parameters);
        }

        [Test]
        public void Parse_ThrowsNullReferenceException_WhenInputParamIsNull()
        {
            string input = null;
            Assert.Throws<NullReferenceException>(() => Command.Parse(input));
        }

        [TestCase(" ForMale Cool")]
        public void Parse_ThrowsArgumentNullExceptionWithCorrectMessage_WhenNameParameterIsNullOrEmpty(string input)
        {
            Assert.That(() => Command.Parse(input), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [TestCase("CreateCategory ")]
        public void Parse_ThrowsArgumentNullExceptionWithCorrectMessage_WhenPropertiesParametersAreInvalid(string input)
        {
            //Assert.That(() => Command.Parse(input), Throws.ArgumentNullException.With.Message.Contains("List"));
            try
            {
                Command.Parse(input);
            }
            catch (ArgumentNullException ex)
            {
                var message = ex.Message;
                if (message.Contains("List"))
                {
                    return;
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.Fail();
        }


    }
}
