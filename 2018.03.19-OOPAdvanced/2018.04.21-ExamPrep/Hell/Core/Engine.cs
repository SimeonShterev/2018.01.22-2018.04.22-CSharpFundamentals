using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
	private IReader reader;
	private IWriter writer;
	private IManager manager;
	private ICommandInterpreter commandInterpreter;

	public Engine(IReader reader, IWriter writer, IManager manager, ICommandInterpreter commandInterpreter)
	{
		this.reader = reader;
		this.writer = writer;
		this.manager = manager;
		this.commandInterpreter = commandInterpreter;
	}

	public void Run()
	{
		bool isRunning = true;

		while (isRunning)
		{
			string inputLine = this.reader.ReadLine().Trim();
			IList<string> arguments = inputLine.Split().ToList();

			string output = this.commandInterpreter.ProcessCommand(arguments);
			this.writer.WriteLine(output);

			isRunning = ShouldEnd(inputLine);
		}
	}

	private bool ShouldEnd(string inputLine)
	{
		if (inputLine != "Quit")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}