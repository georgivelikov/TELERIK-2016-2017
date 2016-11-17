using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework;

using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.CommandsTests
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Expect_ToSuccessfullyCreateCommand_WhenConstructorIsCalled()
        {
            var teacherAddMarkCommand = new TeacherAddMarkCommand();

            Assert.IsInstanceOf<TeacherAddMarkCommand>(teacherAddMarkCommand);
        }

        [Test]
        public void Expect_ExecuteMethod_ToThrowInvalidOperationException_WhenInvalidStudentIdIsPassed()
        {
            var studentId = "0";
            var teacherId = "0";
            var mark = "5";

            var teacherAddMarkCommand = new TeacherAddMarkCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { studentId, teacherId, mark };
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();
            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns((IStudent)null);
            dataMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);

            Assert.Throws<InvalidOperationException>(() => teacherAddMarkCommand.Execute(parameters, dataMock.Object));
        }

        [Test]
        public void Expect_ExecuteMethod_ToThrowInvalidOperationException_WhenInvalidTeacherIdIsPassed()
        {
            var studentId = "0";
            var teacherId = "0";
            var mark = "5";

            var teacherAddMarkCommand = new TeacherAddMarkCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { studentId, teacherId, mark };
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();
            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            dataMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns((ITeacher)null);

            Assert.Throws<InvalidOperationException>(() => teacherAddMarkCommand.Execute(parameters, dataMock.Object));
        }

        [Test]
        public void Expect_ExecuteMethod_ToSuccessfullyCallTeacherAddMarkMethod_WhenValidArgumentsArePassed()
        {
            var studentId = "0";
            var teacherId = "0";
            var mark = "5";

            var teacherAddMarkCommand = new TeacherAddMarkCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { studentId, teacherId, mark };
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<int>())).Verifiable();

            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            dataMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);
            
            teacherAddMarkCommand.Execute(parameters, dataMock.Object);

            teacherMock.Verify(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Expect_ExecuteMethod_ToReturnCorrectMessage_WhenValidArgumentsArePassed()
        {
            var studentId = "0";
            var teacherId = "0";
            var mark = "5";

            var teacherAddMarkCommand = new TeacherAddMarkCommand();
            var dataMock = new Mock<ISchoolSystemData>();
            var parameters = new List<string>() { studentId, teacherId, mark };
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.FirstName).Returns("Georgi");
            studentMock.SetupGet(x => x.LastName).Returns("Georgiev");

            var teacherMock = new Mock<ITeacher>();
            teacherMock.Setup(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<int>())).Verifiable();
            teacherMock.SetupGet(x => x.FirstName).Returns("Petar");
            teacherMock.SetupGet(x => x.LastName).Returns("Petrov");
            teacherMock.SetupGet(x => x.Subject).Returns(Subject.Math);

            dataMock.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(studentMock.Object);
            dataMock.Setup(x => x.GetTeacher(It.IsAny<int>())).Returns(teacherMock.Object);

            var result = teacherAddMarkCommand.Execute(parameters, dataMock.Object);

            var expectedResult =
                $"Teacher Petar Petrov added mark 5 to student Georgi Georgiev in Math.";

            Assert.AreEqual(result, expectedResult);
        }
    }
}
