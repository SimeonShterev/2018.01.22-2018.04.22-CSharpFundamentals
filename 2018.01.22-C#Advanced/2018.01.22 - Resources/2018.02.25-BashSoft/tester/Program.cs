using System;
using System.Linq;
using System.Collections.Generic;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {

            var student = new Student("Pesho");

            var grade = new Grade("Pesheva", 6);
            var grade1 = new Grade("Ivanka", 5);
            var grade2 = new Grade("Petranka", 4);
            var grade3 = new Grade("Dimitri4ka", 3);


            student.AddGrade(grade);
            student.AddGrade(grade1);
            student.AddGrade(grade2);
            student.AddGrade(grade3);

            student.Grades.First().Value = 123;


            //Namee holderName = new Namee();
            //string command;
            //while ((command = Console.ReadLine()) != "end")
            //{
            //    holderName.AddNameToListOfNames(command);
            //}
            //Console.WriteLine();
            //holderName.GetListWithNames.Select(i => "pesho").ToList();
            //Console.WriteLine();
            ////   foreach (var n in name.GetListWithNames)
            ////    {
            ////        Console.WriteLine(n);
            ////    }
            ////}
        }
    }
}
