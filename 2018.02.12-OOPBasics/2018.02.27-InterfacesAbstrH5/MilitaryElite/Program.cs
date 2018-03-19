using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private const int leutenantsFirstPrivate = 5;

    static void Main(string[] args)
    {
        List<Soldier> list = new List<Soldier>();
        string command = null;
        while ((command = Console.ReadLine()) != "End")
        {
            ParseSoldiers(list, command);
        }
        foreach (var soldier in list)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void ParseSoldiers(List<Soldier> list, string command)
    {
        string[] commandArgs = command.Split();
        string type = commandArgs[0];
        int id = int.Parse(commandArgs[1]);
        string firstName = commandArgs[2];
        string lastName = commandArgs[3];
        try
        {
            switch (type)
            {
                case "Private":
                    ParsePrivate(list, id, firstName, lastName, commandArgs);
                    break;
                case "LeutenantGeneral":
                    ParseLeutenant(list, id, firstName, lastName, commandArgs);
                    break;
                case "Engineer":
                    ParseEngineer(list, id, firstName, lastName, commandArgs);
                    break;
                case "Commando":
                    ParseCommando(list, id, firstName, lastName, commandArgs);
                    break;
                case "Spy":
                    ParseSpy(list, id, firstName, lastName, commandArgs);
                    break;
            }
        }
        catch (ArgumentException ex)
        {
        }
    }

    private static void ParseSpy(List<Soldier> list, int id, string firstName, string lastName, string[] commandArgs)
    {
        int codeNumber = int.Parse(commandArgs[4]);
        Spy spy = new Spy(id, firstName, lastName, codeNumber);
        list.Add(spy);
    }

    private static void ParseCommando(List<Soldier> list, int id, string firstName, string lastName, string[] commandArgs)
    {
        double salary = ParseSalary(commandArgs);
        Commando commando = new Commando(id, firstName, lastName, salary);
        string corps = commandArgs[5];
        commando.DefineCorpsType(corps);
        for (int i = 6; i < commandArgs.Length; i += 2)
        {
            try
            {
                string missionName = commandArgs[i];
                string missionState = commandArgs[i + 1];
                Mission mission = new Mission(missionName, missionState);
                commando.AddMission(mission);
            }
            catch (ArgumentException ex)
            {
            }
        }
        list.Add(commando);
    }

    private static void ParseEngineer(List<Soldier> list, int id, string firstName, string lastName, string[] commandArgs)
    {
        double salary = ParseSalary(commandArgs);
        Engineer engineer = new Engineer(id, firstName, lastName, salary);
        string corps = commandArgs[5];
        engineer.DefineCorpsType(corps);
        for (int i = 6; i < commandArgs.Length; i += 2)
        {
            string partName = commandArgs[i];
            int hoursWorked = int.Parse(commandArgs[i + 1]);
            Repair repair = new Repair(partName, hoursWorked);
            engineer.AddRepair(repair);
        }
        list.Add(engineer);
    }

    private static void ParseLeutenant(List<Soldier> list, int id, string firstName, string lastName, string[] commandArgs)
    {
        double salary = ParseSalary(commandArgs);
        LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastName, salary);
        for (int i = leutenantsFirstPrivate; i < commandArgs.Length; i++)
        {
            int idPrivate = int.Parse(commandArgs[i]);
            ISolder privateSoldier = list.First(s => s.Id == idPrivate);
            leutenant.AddPrivate(privateSoldier);
        }
        list.Add(leutenant);
    }

    private static void ParsePrivate(List<Soldier> list, int id, string firstName, string lastName, string[] commandArgs)
    {
        double salary = ParseSalary(commandArgs);
        Private privateSoldier = new Private(id, firstName, lastName, salary);
        list.Add(privateSoldier);
    }

    private static double ParseSalary(string[] commandArgs)
    {
        return double.Parse(commandArgs[4]);
    }
}