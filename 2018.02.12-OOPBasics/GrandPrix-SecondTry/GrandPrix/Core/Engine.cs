using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
	private ConsoleWriter writer;
	private ConsoleReader reader;
	private RaceTower raceTower;

	public Engine()
	{
		this.writer = new ConsoleWriter();
		this.reader = new ConsoleReader();
		this.raceTower = new RaceTower();
	}

	public void Run()
	{

	}
}