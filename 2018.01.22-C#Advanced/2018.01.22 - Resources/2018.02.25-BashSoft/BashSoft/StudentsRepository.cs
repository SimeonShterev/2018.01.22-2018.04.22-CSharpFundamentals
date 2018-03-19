using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Read0ing data...");
                studentByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                string[] tokens = input.Split(' ');
                string course = tokens[0];
                string student = tokens[1];
                int mark = int.Parse(tokens[2]);

                if (!studentByCourse.ContainsKey(course))
                {
                    studentByCourse.Add(course, new Dictionary<string, List<int>>());
                }
                if (!studentByCourse[course].ContainsKey(student))
                {
                    studentByCourse[course].Add(student, new List<int>());
                }
                studentByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }

        private static bool IsQueryForStudentPossiblе(string courseName, string studentName)
        {
            if (studentByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
            return false;
        }

        public static void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossiblе(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(courseName, studentByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string coureName)
        {
            if (IsQueryForCoursePossible(coureName))
            {
                OutputWriter.WriteMessageOnNewLine($"{coureName}");
                foreach (var studentMarksEntry in studentByCourse[coureName])
                {
                    OutputWriter.PrintStudent(studentMarksEntry);
                }
            }
        }

    }
}
