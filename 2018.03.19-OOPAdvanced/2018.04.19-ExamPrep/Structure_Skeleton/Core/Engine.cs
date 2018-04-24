using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
	private const string EndCommand = "Shutdown";

	private IEnergyRepository energyRepository;
	private ICommandInterpreter commandInterpreter;
	private IWriter writer;
	private IReader reader;

	public Engine(IEnergyRepository energyRepository, ICommandInterpreter commandInterpreter, IWriter writer)
	{
		this.reader = new ConsoleReader();

		this.writer = writer;
		this.energyRepository = energyRepository;
		this.commandInterpreter = commandInterpreter;
	}

	public void Run()
	{
		string output = null;
		while(true)
		{
			IList<string> commandArgs = this.reader.ReadLine().Split().ToList();
			output = this.commandInterpreter.ProcessCommand(commandArgs);
			this.writer.WriteLine(output);
			
			if(commandArgs[0]==EndCommand)
			{
				break;
			}
		}
	}
}
