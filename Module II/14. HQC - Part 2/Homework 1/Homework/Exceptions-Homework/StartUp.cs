using System;
using System.Collections.Generic;

namespace Exceptions_Homework
{
    public class StartUp
    {
        private static void Main()
        {
            Console.WriteLine("Check Subsequence Method:");
            var subStr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(subStr);

            var subArr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subArr));

            var allArr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allArr));

            var emptyArr = Utils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyArr));

            Console.WriteLine("\nCheck ExtractEnding Method:");
            Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utils.ExtractEnding("beer", 4));
            try
            {
                Console.WriteLine(Utils.ExtractEnding("Hi", 100));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nCheck CheckPrime Method:");
            Utils.CheckPrime(23);
            Utils.CheckPrime(33);
            try
            {
                Utils.CheckPrime(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nCheck Student Exams:");
            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0)
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
