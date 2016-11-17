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
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Expect_ToSuccessfullyCreateCommand_WhenConstructorIsCalled()
        {
            var removeStudentCommand = new RemoveStudentCommand();

            Assert.IsInstanceOf<RemoveStudentCommand>(removeStudentCommand);
        }

        [Test]
        public void Expect_ExecuteMethod_ToCallDataRemoveStudentOnce_WhenValidParametersArePassed()
        {
            var id = "0";
            var removeStudentCommand = new RemoveStudentCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { id };
            var studentMock = new Mock<IStudent>();
            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);

            removeStudentCommand.Execute(parameters, dataMock.Object);

            dataMock.Verify(x => x.RemoveStudent(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Expect_ExecuteMethod_ToThrowInvalidOperationException_WhenPassedIdIsNotPressentInDatabase()
        {
            var id = "0";
            var removeStudentCommand = new RemoveStudentCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { id };
            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns((IStudent)null);

            Assert.Throws<InvalidOperationException>(() => removeStudentCommand.Execute(parameters, dataMock.Object));
        }

        [Test]
        public void Expect_ExecuteMethod_ToReturnCorrectMessage_WhenValidParameterIsPassed()
        {
            var id = "0";
            var expectedId = 0;
            var removeStudentCommand = new RemoveStudentCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { id };
            var studentMock = new Mock<IStudent>();
            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);

            var result = removeStudentCommand.Execute(parameters, dataMock.Object);

            var expectedResult = $"Student with ID {expectedId} was sucessfully removed.";

            Assert.AreEqual(result, expectedResult);
        }
    }
}
