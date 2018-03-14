using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		DraftManager draftManager = new DraftManager();
		string input;
		while ((input = Console.ReadLine())!="Shutdown")
		{
				List<string> commandArgs = input.Split().ToList();
				string command = commandArgs[0];
				commandArgs.RemoveAt(0);
				string result = string.Empty;
				switch (command)
				{
					case "RegisterHarvester":
						result = draftManager.RegisterHarvester(commandArgs);
						Console.WriteLine(result);
						break;
					case "RegisterProvider":
						result = draftManager.RegisterProvider(commandArgs);
						Console.WriteLine(result);
						break;
					case "Day":
						result = draftManager.Day();
						Console.WriteLine(result);
						break;
					case "Mode":
						result = draftManager.Mode(commandArgs);
						Console.WriteLine(result);
						break;
					case "Check":
						result = draftManager.Check(commandArgs);
						Console.WriteLine(result);
						break;
				}
		}
		string shutdown = draftManager.ShutDown();
		Console.WriteLine(shutdown);
	}
}