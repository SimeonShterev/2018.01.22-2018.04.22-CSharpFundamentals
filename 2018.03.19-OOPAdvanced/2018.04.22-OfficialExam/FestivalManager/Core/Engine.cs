using FestivalManager.Constants;
using FestivalManager.Core.Contracts;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Core.IO;
using FestivalManager.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Core
{
	public class Engine : IEngine
	{
		private IReader reader;
		private IWriter writer;
		private IFestivalController festivalController;
		private ISetController setController;

		public Engine(IFestivalController festivalController, ISetController setController)
		{
			this.festivalController = festivalController;
			this.setController = setController;

			this.writer = new ConsoleWriter();
			this.reader = new ConsoleReader();
		}

		public void Run()
		{
			while (true)
			{
				string input = this.reader.ReadLine().Trim();

				try
				{
					string output = ProcessCommand(input);
					this.writer.Write(output);
				}
				catch (InvalidOperationException ex)
				{
					this.writer.Write(string.Format(Consts.Error, ex.Message));
				}

				if (input == "END")
				{
					this.writer.WriteLine(this.festivalController.ProduceReport().Trim());
					break;
				}
				this.writer.WriteLine(null);
			}
		}

		public string ProcessCommand(string input)
		{
			IList<string> args = input.Split().ToList();
			string commandName = args[0];
			string[] commandArgs = args.Skip(1).ToArray();

			string output = null;
			switch (commandName)
			{
				case "RegisterSet":
					output = this.festivalController.RegisterSet(commandArgs);
					break;
				case "SignUpPerformer":
					output = this.festivalController.SignUpPerformer(commandArgs);
					break;
				case "RegisterSong":
					output = this.festivalController.RegisterSong(commandArgs);
					break;
				case "AddSongToSet":
					output = this.festivalController.AddSongToSet(commandArgs);
					break;
				case "AddPerformerToSet":
					output = this.festivalController.AddPerformerToSet(commandArgs);
					break;
				case "RepairInstruments":
					output = this.festivalController.RepairInstruments(commandArgs);
					break;
				case "LetsRock":
					output = this.setController.PerformSets();
					break;
			}

			return output;
		}
	}
}
