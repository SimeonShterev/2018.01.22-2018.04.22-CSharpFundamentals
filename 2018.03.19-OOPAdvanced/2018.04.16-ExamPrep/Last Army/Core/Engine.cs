using System;

public class Engine
{
	private IWriter writer;
	private IReader reader;
	private GameController gameController;

	public Engine()
	{
		this.writer = new ConsoleWriter();
		this.reader = new ConsoleReader();
		this.gameController = new GameController(this.writer);
	}

	public void Run()
	{
		string input;

		while ((input=this.reader.ReadLine())!="Enough! Pull back!")
		{
			try
			{
				gameController.GiveInputToGameController(input);
			}
			catch (ArgumentException arg)
			{
				this.writer.Append(arg.Message);
			}
		}

		this.gameController.ProduceSummary();
	}
}