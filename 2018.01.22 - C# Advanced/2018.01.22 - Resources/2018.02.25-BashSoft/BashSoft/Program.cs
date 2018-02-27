using System;
using System.IO;

namespace BashSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            //IOManager.TraverseDirectory(Directory.GetCurrentDirectory());
            StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }

    }
}
