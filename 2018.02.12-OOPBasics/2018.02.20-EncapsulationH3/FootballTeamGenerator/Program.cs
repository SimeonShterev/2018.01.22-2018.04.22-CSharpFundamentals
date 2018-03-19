using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teamsList = new List<Team>();
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split(';');
            string mainCommand = commandArgs[0];
            switch (mainCommand)
            {
                case "Team":
                    ParseTeam(commandArgs, teamsList);
                    break;
                case "Add":
                    AddPlayerToTeam(commandArgs, teamsList);
                    break;
                case "Remove":
                    RemovePlayerFromTeam(commandArgs, teamsList);
                    break;
                case "Rating":
                    string teamName = commandArgs[1];
                    RateTeam(teamsList, teamName);
                    break;
            }
        }
    }

    private static void RateTeam(List<Team> teamsList, string teamName)
    {
        Team notExistingTeam = teamsList.Find(t => t.Name == teamName);
        if (notExistingTeam == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }
        int rate = 0;
        Team team = teamsList.Find(t => t.Name == teamName);
        if (team.PlayersCount == 0)
        {
            Console.WriteLine($"{teamName} - 0");
            Environment.Exit(0);
        }
        rate = team.CalculateRate(team);
        Console.WriteLine($"{teamName} - {rate}");
    }


    private static void RemovePlayerFromTeam(string[] commandArgs, List<Team> teamsList)
    {
        try
        {
            string nameOfTeam = commandArgs[1];
            string playerName = commandArgs[2];
            Team notExistingTeam = teamsList.Find(t => t.Name == nameOfTeam);
            if (notExistingTeam == null)
            {
                Console.WriteLine($"Team {nameOfTeam} does not exist.");
                return;
            }
            Team team = teamsList.Find(t => t.Name == nameOfTeam);
            team.RemovePlayer(playerName);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void AddPlayerToTeam(string[] commandArgs, List<Team> teamsList)
    {
        try
        {
            string nameOfTeam = commandArgs[1];
            string playerName = commandArgs[2];
            double overallSkill = 0.0;
            for (int i = 3; i < 8; i++)
            {
                overallSkill += CheckValidity(int.Parse(commandArgs[i]), i - 3);
            }
            overallSkill /= 5;
            Player player = new Player(playerName, overallSkill);
            Team notExistingTeam = teamsList.Find(t => t.Name == nameOfTeam);
            if (notExistingTeam == null)
            {
                Console.WriteLine($"Team {nameOfTeam} does not exist.");
                return;
            }
            Team team = teamsList.Find(t => t.Name == nameOfTeam);
            team.AddPlayer(player);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ParseTeam(string[] commandArgs, List<Team> teamsList)
    {
        try
        {
            string teamName = commandArgs[1];
            Team team = new Team(teamName);
            teamsList.Add(team);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static int CheckValidity(int skillLevel, int skill)
    {
        if (skillLevel < 0 || skillLevel > 100)
        {
            switch (skill)
            {
                case 0:
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                case 1:
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                case 2:
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                case 3:
                    throw new ArgumentException("Passing  should be between 0 and 100.");
                case 4:
                    throw new ArgumentException("Shooting should be between 0 and 100.");
            }
        }
        return skillLevel;
    }
}