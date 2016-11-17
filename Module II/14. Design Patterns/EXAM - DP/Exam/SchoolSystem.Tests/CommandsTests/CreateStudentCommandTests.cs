using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.CommandsTests
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void ExpectedToThrowArgumentNullException_WhenInvalidArgumentIsPassedInConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(null));
        }

        [Test]
        public void ExpectedToSuccessfullyCreateCommand_WhenValiArgumentIsPassed()
        {
            var studentFactoryMock = new Mock<IStudentFactory>();

            var createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object);

            Assert.IsInstanceOf<CreateStudentCommand>(createStudentCommand);
        }

        [Test]
        public void ExpectExecuteMethod_ToCallDataAddStudentMethodOnce_WhenValiArgumentsArePassed()
        {
            var firstName = "Georgi";
            var lastName = "Georgiev";
            var grade = "6";

            var expectedFirstName = "Georgi";
            var expectedLastName = "Georgiev";
            var expectedGrade = "Sixth";

            var studentFactoryMock = new Mock<IStudentFactory>();
            var dataMock = new Mock<ISchoolSystemData>();

            var parameters = new List<string>() { firstName, lastName, grade };

            var createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object);

            createStudentCommand.Execute(parameters, dataMock.Object);

            dataMock.Verify(x => x.AddStudent(It.IsAny<IStudent>()), Times.Once);
        }

        [Test]
        public void ExpectExecuteMethod_ToReturnSuccessfullMessage_WhenValiArgumentsArePassed()
        {
            var firstName = "Georgi";
            var lastName = "Georgiev";
            var grade = "6";

            var expectedFirstName = "Georgi";
            var expectedLastName = "Georgiev";
            var expectedGrade = "Sixth";

            var studentFactoryMock = new Mock<IStudentFactory>();
            var dataMock = new Mock<ISchoolSystemData>();
            dataMock.Setup(x => x.LastStudentId()).Returns(0);

            var parameters = new List<string>() { firstName, lastName, grade };

            var createStudentCommand = new CreateStudentCommand(studentFactoryMock.Object);

            var result = createStudentCommand.Execute(parameters, dataMock.Object);
            var expected =
                $"A new student with name {expectedFirstName} {expectedLastName}, grade {expectedGrade} and ID 0 was created.";

            Assert.AreEqual(result, expected);
        }
    }
}
