using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<DateTime> list = new List<DateTime>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            DateTime birthDate = new DateTime();
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = tokens[0];
            string name = tokens[1];
            switch (type)
            {
                case "Citizen":
                    birthDate = GenerateBirthDate(tokens);
                    int age = int.Parse(tokens[2]);
                    string personId = tokens[3];
                    Person person = new Person(personId, name, age, birthDate);
                    list.Add(birthDate);
                    break;
                case "Pet":
                    birthDate = GenerateBirthDate(tokens);
                    Pet pet = new Pet(name, birthDate);
                    list.Add(birthDate);

                    break;
                case "Robot":
                    string robotId = tokens[2];
                    Robot robot = new Robot(robotId, name);
                    break;
                default:
                    break;
            }
        }
        int year = int.Parse(Console.ReadLine());
        foreach (var date in list)
        {
            if (date.Year == year)
            {
                Console.WriteLine($"{date.Day:d2}/{date.Month:d2}/{date.Year:d4}");
            }
        }
    }

    private static DateTime GenerateBirthDate(string[] tokens)
    {
        int[] birthDateArr = tokens[tokens.Length - 1].Split('/').Select(int.Parse).ToArray();
        int day = birthDateArr[0];
        int month = birthDateArr[1];
        int year = birthDateArr[2];
        DateTime birthDate = new DateTime(year, month, day);
        return birthDate;
    }
}