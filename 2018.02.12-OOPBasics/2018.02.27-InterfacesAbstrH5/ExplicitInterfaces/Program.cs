using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        MyPrivateList list = new MyPrivateList();
        string command;
        while ((command=Console.ReadLine())!="End")
        {
            string[] input = command.Split();
            string name = input[0];
            string country = input[1];
            int age = int.Parse(input[2]);
            Citizen citizen = new Citizen(name, country, age);
            list.AddCitizensToList(citizen);
            IPerson citizenAsPerson = (IPerson)citizen;
            IResident citizenAsResident = (IResident)citizen;
            Console.WriteLine(citizenAsPerson.GetName());
            Console.WriteLine(citizenAsResident.GetName());
        }
        var result = list.ReadList;
        foreach (var item in result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(item.Name).AppendLine(item.Country).AppendLine(item.Age.ToString());
            Console.WriteLine(sb);
        }
    }
} 