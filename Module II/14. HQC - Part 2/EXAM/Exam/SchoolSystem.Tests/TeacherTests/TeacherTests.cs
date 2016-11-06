using System;
using SchoolSystem.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using NUnit.Framework;
using Moq;

namespace SchoolSystem.Tests.TeacherTests
{
    [TestFixture]
    public class TeacherTests
    {
        [TestCase("s")]
        [TestCase("toooooooooooooooooooooooooooooooooooooooooooooooo_Looooooooooooooooooooooong")]
        public void ExpectToThrowArgumentException_WhenInvalidFirstNameLenghtIsPassed(string firstName)
        {
            string lastName = "valid";
            SubjectEnum subject = SubjectEnum.Math;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [TestCase("s")]
        [TestCase("toooooooooooooooooooooooooooooooooooooooooooooooo_Looooooooooooooooooooooong")]
        public void ExpectToThrowArgumentException_WhenInvalidLastNameLenghtIsPassed(string lastName)
        {
            string firstName = "valid";
            SubjectEnum subject = SubjectEnum.Math;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [TestCase("s12$")]
        [TestCase("41234124@@2")]
        public void ExpectToThrowArgumentException_WhenInvalidFirstNameSymbolsArePassed(string firstName)
        {
            string lastName = "valid";
            SubjectEnum subject = SubjectEnum.Math;;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [TestCase("s12$")]
        [TestCase("41234124@@2")]
        public void ExpectToThrowArgumentException_WhenInvalidLastNameSymbolsArePassed(string lastName)
        {
            string firstName = "valid";
            SubjectEnum subject = SubjectEnum.Math; ;

            Assert.Throws<ArgumentException>(() => new Teacher(firstName, lastName, subject));
        }

        [Test]
        public void ExpectToCallStudentAddMarkOnce_WhenTeacherAddMarkIsCalled()
        {
            var studentMock = new Mock<IStudent>();
            var markValue = 3;
            var teacher = new Teacher("Petar", "Petrov", SubjectEnum.Math);

            teacher.AddMark(studentMock.Object, markValue);

            studentMock.Verify(x => x.AddMark(It.IsAny<IMark>()), Times.Once);
        }
    }
}
