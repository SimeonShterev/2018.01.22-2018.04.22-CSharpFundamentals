using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		Engine engine = new Engine();
		string input;
		while ((input = Console.ReadLine())!= "Paw Paw Pawah")
		{
			List<string> commandArgs = input.Split().ToList();
			string command = commandArgs[0];
			commandArgs.RemoveAt(0);
			switch(command)
			{
				case "RegisterAdoptionCenter":
					engine.RegisterAdoptionCenter(commandArgs[0]);
					break;
				case "RegisterCleansingCenter":
					engine.RegisterCleansingCenter(commandArgs[0]);
					break;
				case "RegisterCastrationCenter":
					engine.RegisterCastrationCenter(commandArgs[0]);
					break;
				case "RegisterDog":
					engine.RegisterDog(commandArgs);
					break;
				case "RegisterCat":
					engine.RegisterCat(commandArgs);
					break;
				case "SendForCleansing":
					engine.SendForCleasing(commandArgs);
					break;
				case "Cleanse":
					engine.Cleanse(commandArgs[0]);
					break;
				case "SendForCastration":
					engine.SendForCastration(commandArgs);
					break;
				case "Castrate":
					engine.Castrate(commandArgs[0]);
					break;
				case "Adopt":
					engine.Adopt(commandArgs[0]);
					break;

			}
		}
	}
}