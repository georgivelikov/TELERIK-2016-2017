using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using SchoolSystem.Contracts;
using SchoolSystem.Core;
using SchoolSystem.Commands;

namespace SchoolSystem.Tests.EngineTests
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void EngineShouldSuccessfullyCreate_CreateStudentCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("CreateStudent");

            Assert.IsInstanceOf<CreateStudentCommand>(result);
        }

        [Test]
        public void EngineShouldSuccessfullyCreate_CreateTeacherCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("CreateTeacher");

            Assert.IsInstanceOf<CreateTeacherCommand>(result);
        }

        [Test]
        public void EngineShouldSuccessfullyCreate_RemoveTeacherCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("RemoveTeacher");

            Assert.IsInstanceOf<RemoveTeacherCommand>(result);
        }

        [Test]
        public void EngineShouldSuccessfullyCreate_RemoveStudentCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("RemoveStudent");

            Assert.IsInstanceOf<RemoveStudentCommand>(result);
        }

        [Test]
        public void EngineShouldSuccessfullyCreate_StudentListMarksCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("StudentListMarks");

            Assert.IsInstanceOf<StudentListMarksCommand>(result);
        }

        [Test]
        public void EngineShouldSuccessfullyCreate_TeacherAddMarksCommand_WhenValidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            var result = engine.CreateCommand("TeacherAddMark");

            Assert.IsInstanceOf<TeacherAddMarkCommand>(result);
        }

        [Test]
        public void EngineShouldThrowArgumentException_WhenInvalidParamsArePassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();

            var engine = new Engine(reader.Object, writer.Object, data.Object);

            Assert.Throws<ArgumentException>(() => engine.CreateCommand("Invalid INvalid"));
        }

        [Test]
        public void ExecuteCommand_ShoultCallCommandExecuteMethoOnce()
        {
            var command = new Mock<ICommand>();
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var data = new Mock<ISchoolSystemData>();
            var commandArgs = new List<string>();
            var engine = new Engine(reader.Object, writer.Object, data.Object);

            engine.ExecuteCommand(command.Object, commandArgs, data.Object);

            command.Verify(x => x.Execute(commandArgs, data.Object), Times.Once);
        }
    }
}
