using System;
using SchoolSystem.Contracts;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using NUnit.Framework;
using Moq;

namespace SchoolSystem.Tests.StudentTests
{
    [TestFixture]
    public class StudentTests
    {
        [TestCase("s")]
        [TestCase("toooooooooooooooooooooooooooooooooooooooooooooooo_Looooooooooooooooooooooong")]
        public void ExpectToThrowArgumentException_WhenInvalidFirstNameLenghtIsPassed(string firstName)
        {
            string lastName = "valid";
            GradeEnum grade = GradeEnum.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [TestCase("s12$")]
        [TestCase("41234124@@2")]
        public void ExpectToThrowArgumentException_WhenInvalidFirstNameSymbolsArePassed(string firstName)
        {
            string lastName = "valid";
            GradeEnum grade = GradeEnum.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [TestCase("s")]
        [TestCase("toooooooooooooooooooooooooooooooooooooooooooooooo_Looooooooooooooooooooooong")]
        public void ExpectToThrowArgumentException_WhenInvalidLastNameLenghtIsPassed(string lastName)
        {
            string firstName = "valid";
            GradeEnum grade = GradeEnum.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [TestCase("s12$")]
        [TestCase("41234124@@2")]
        public void ExpectToThrowArgumentException_WhenInvalidLastNameSymbolsArePassed(string lastName)
        {
            string firstName = "valid";
            GradeEnum grade = GradeEnum.Eighth;

            Assert.Throws<ArgumentException>(() => new Student(firstName, lastName, grade));
        }

        [Test]
        public void ExpectAddMark_ToSuccefullyAddMarkToMarksCollection()
        {
            var newMark = new Mock<IMark>();
            var student = new Student("Petar", "Petrov", GradeEnum.Eighth);

            student.AddMark(newMark.Object);

            Assert.AreEqual(student.MarksCount, 1);
        }

        [Test]
        public void ExpectAddMark_ToThrowInvalidOperationException_WhenMoreThanTwentyMarksAreAdded()
        {
            var newMark = new Mock<IMark>();
            var student = new Student("Petar", "Petrov", GradeEnum.Eighth);

            for (int i = 0; i < 20; i++)
            {
                student.AddMark(newMark.Object);
            }

            Assert.Throws<InvalidOperationException>(() => student.AddMark(newMark.Object));
        }

        [Test]
        public void ExpectListMarks_ToReturnCorrectMessageWhenNoMarksAreAdded()
        {
            var student = new Student("Petar", "Petrov", GradeEnum.Eighth);
            var expected = "This student has no marks.";

            var result = student.ListMarks();

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void ExpectListMarks_ToReturnCorrectMessageWhenMarksAreAdded()
        {
            var newMark = new Mock<IMark>();
            newMark.SetupGet(x => x.Subject).Returns(SubjectEnum.Math);
            newMark.SetupGet(x => x.MarkValue).Returns(6);
            var student = new Student("Petar", "Petrov", GradeEnum.Eighth);
            student.AddMark(newMark.Object);
            var expected = "The student has these marks:\r\nMath => 6\n";

            var result = student.ListMarks();

            Assert.AreEqual(result, expected);
        }
    }
}
