using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> list = new List<Person>();
        string input;
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] data = Console.ReadLine().Split();
            if(data.Length==4)
            {
                Citizen citizen = new Citizen(data[0], int.Parse(data[1]));
                list.Add(citizen);
            }
            else
            {
                Rebel rebel = new Rebel(data[0], int.Parse(data[1]), data[2]);
                list.Add(rebel);
            }
        }
        int food = 0;
        while ((input = Console.ReadLine()) != "End")
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i].Name==input)
                {
                    if(list[i].GetType().Name=="Citizen")
                    {
                        food += 10;
                    }
                    else
                    {
                        food += 5;
                    }
                }
            }
        }
        Console.WriteLine(food);
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