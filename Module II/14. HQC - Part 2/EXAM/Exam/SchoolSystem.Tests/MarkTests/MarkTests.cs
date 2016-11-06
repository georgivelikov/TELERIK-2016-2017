using System;
using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystem.Tests.MarkTests
{
    [TestFixture]
    public class MarkTests
    {
        [TestCase(7)]
        [TestCase(0)]
        public void ExpectsToThrowArgumentException_WhenTryToCreateMarkWithInvalidValue(float markValue)
        {
            Assert.Throws<ArgumentException>(() => new Mark(SubjectEnum.Math, markValue));
        }
    }
}
