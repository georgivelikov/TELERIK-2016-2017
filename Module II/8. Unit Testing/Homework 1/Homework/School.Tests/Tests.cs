namespace School.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestIfStudentIsCreatedWhenValidArgumentsArePassed()
        {
            // Arange
            var school = new School();
            string name = "Ivan";
            int studentNumber = school.GenerateStudentId();

            // Act
            var student = new Student(name, studentNumber);

            // Assert
            Assert.IsNotNull(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenStudentNameIsEmptyString()
        {
            // Arange
            var school = new School();
            string name = string.Empty;
            int studentNumber = school.GenerateStudentId();

            // Act
            var student = new Student(name, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenStudentNameIsNull()
        {
            // Arange
            var school = new School();
            string name = null;
            int studentNumber = school.GenerateStudentId();

            // Act
            var student = new Student(name, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenStudentNameIsWhiteSpace()
        {
            // Arange
            var school = new School();
            string name = "          ";
            int studentNumber = school.GenerateStudentId();

            // Act
            var student = new Student(name, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenStudentNumberIsInvalid()
        {
            // Arange
            var school = new School();
            string name = "Ivan";
            int studentNumber = 1;

            // Act
            var student = new Student(name, studentNumber);
        }

        [TestMethod]
        public void TestIfCourseIsCreatedWhenValidArgumentsArePassed()
        {
            // Arange
            string courseName = "Maths";

            // Act
            var course = new Course(courseName);

            // Assert
            Assert.IsNotNull(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenCourseNameIsEmptyString()
        {
            // Arange
            string courseName = string.Empty;

            // Act
            var course = new Course(courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenCourseNameIsNull()
        {
            // Arange
            string courseName = null;

            // Act
            var course = new Course(courseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfErrorIsTrownWhenCourseNameIsWhiteSpace()
        {
            // Arange
            string courseName = "    ";

            // Act
            var course = new Course(courseName);
        }

        [TestMethod]
        public void TestIfCoursesAreCorrectlyAddedToTheSchool()
        {
            // Arange
            var school = new School();
            string courseName1 = "Maths";
            string courseName2 = "Geography";
            string courseName3 = "History";

            var maths = new Course(courseName1);
            var geography = new Course(courseName2);
            var history = new Course(courseName3);

            // Act
            school.AddCourse(maths);
            school.AddCourse(geography);
            school.AddCourse(history);

            int expectedCountOfCourses = 3;
            int actualCountOfCourses = school.Courses.Count;

            // Assert
            Assert.AreEqual(expectedCountOfCourses, actualCountOfCourses);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfAddCourseMehodThrowsErrorWhenTryToAddTheSameCourseTwice()
        {
            // Arange
            var school = new School();
            string courseName1 = "Maths";
            string courseName2 = "Geography";
            string courseName3 = "History";

            var maths = new Course(courseName1);
            var geography = new Course(courseName2);
            var history = new Course(courseName3);

            // Act
            school.AddCourse(maths);
            school.AddCourse(geography);
            school.AddCourse(history);
            school.AddCourse(history);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfAddCourseMethodThrowsErrorWhenTryToAddCoursesWithTheSameName()
        {
            // Arange
            var school = new School();
            string courseName1 = "Maths";
            string courseName2 = "Geography";
            string courseName3 = "History";
            string courseName4 = "History";

            var maths = new Course(courseName1);
            var geography = new Course(courseName2);
            var history = new Course(courseName3);
            var otherHistory = new Course(courseName4);

            // Act
            school.AddCourse(maths);
            school.AddCourse(geography);
            school.AddCourse(history);
            school.AddCourse(otherHistory);
        }

        [TestMethod]
        public void TestAddStudentsMethodAddCorrectlyStudentsToTheCourse()
        {
            var student1 = new Student("Ivan", 22222);
            var student2 = new Student("Petar", 22333);
            var student3 = new Student("Maria", 33332);

            var course = new Course("Maths");

            course.AddStudent(student1);
            course.AddStudent(student2);
            course.AddStudent(student3);

            int expected = 3;
            int actual = course.Students.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfAddStudentMethodThrowsExceptionWhenYouTryToAddTheSameStudentTwice()
        {
            var student1 = new Student("Ivan", 22222);
            var student2 = new Student("Petar", 22333);
            var student3 = new Student("Maria", 33332);

            var course = new Course("Maths");

            course.AddStudent(student1);
            course.AddStudent(student2);
            course.AddStudent(student1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfAddStudentMethodThrowsExceptionWhenStudentIsNull()
        {
            Student student1 = null;

            var course = new Course("Maths");

            course.AddStudent(student1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfAddStudentMethodThrowsExceptionWhenYouTryToAddMoreThan29Students()
        {
            var school = new School();
            var course = new Course("History");
            for (int i = 0; i < 50; i++)
            {
                string name = "Ivan" + i;
                int num = school.GenerateStudentId();
                var st = new Student(name, num);
                course.AddStudent(st);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIfRemovetudentMethodThrowsExceptionWhenYouTryToRemoveStudentThatIsNotInTheCourse()
        {
            var student1 = new Student("Ivan", 22222);
            var student2 = new Student("Petar", 22333);
            var student3 = new Student("Maria", 33332);

            var course = new Course("Maths");

            course.AddStudent(student1);
            course.AddStudent(student2);

            course.RemoveStudent(student3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfRemoveStudentMethodThrowsExceptionWhenStudentIsNull()
        {
            Student student1 = null;
            Student student2 = new Student("Georgi", 23123);
            var course = new Course("Maths");
            course.AddStudent(student2);
            course.RemoveStudent(student1);
        }

        [TestMethod]
        public void TestIfRemoveStudentWorksAsExpectedWhenStudentIsRemoved()
        {
            var student1 = new Student("Ivan", 22222);
            var student2 = new Student("Petar", 22333);
            var student3 = new Student("Maria", 33332);

            var course = new Course("Maths");

            course.AddStudent(student1);
            course.AddStudent(student2);
            course.AddStudent(student3);

            course.RemoveStudent(student3);

            var expected = 2;
            var actual = course.Students.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIfRemoveStudentWorksAsExpectedAndRemovesExactlyTheDesiredStudent()
        {
            var student1 = new Student("Ivan", 22222);
            var student2 = new Student("Petar", 22333);
            var student3 = new Student("Maria", 33332);

            var course = new Course("Maths");

            course.AddStudent(student1);
            course.AddStudent(student2);
            course.AddStudent(student3);

            course.RemoveStudent(student2);

            bool checker = course.Students.Any(x => x.StudentNumber == student2.StudentNumber);

            Assert.IsFalse(checker);
        }
    }
}
