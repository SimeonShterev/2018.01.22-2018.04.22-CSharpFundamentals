using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        var personList = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
            personList.Add(person);
        }
        Team team = new Team("Ebisa");
        foreach(var person in personList)
        {
            team.AddPlayer(person);
        }
        int firstTeamCount = team.FirstTeam.Count;
        Console.WriteLine($"First team has {firstTeamCount} players.");
        int secondTeamCount = team.ReverseTeam.Count;
        Console.WriteLine($"Reverse team has {secondTeamCount} players.");
        string myString = "old string";
        myString.Replace("old", "new ")
    }
}