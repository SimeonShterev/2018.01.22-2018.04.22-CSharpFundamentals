using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		NationsBuilder nationBuilder = new NationsBuilder();
		string input;
		while ((input = Console.ReadLine())!="Quit")
		{
			List<string> commandArgs = input.Split().ToList();
			string command = commandArgs[0];
			commandArgs.RemoveAt(0);
			string nationsType = commandArgs[0];
			switch (command)
			{
				case "Bender":
					nationBuilder.AssignBender(commandArgs);
					break;
				case "Monument":
					nationBuilder.AssignMonument(commandArgs);
					break;
				case "Status":
					string status = nationBuilder.GetStatus(nationsType);
					Console.WriteLine(status);
					break;
				case "War":
					nationBuilder.IssueWar(nationsType);
					break;
			}
		}
		string warsRecord = nationBuilder.GetWarsRecord();
		Console.WriteLine(warsRecord);
	}
}