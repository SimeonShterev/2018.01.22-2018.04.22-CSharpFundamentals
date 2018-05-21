using FestivalManager.Constants;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Core.IO;
using FestivalManager.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Core
{
    public class Engine
    {
		private IWriter writer;
		private IReader reader;
		private ISetController setController;
		private IFestivalController festivalController;

		public Engine(IFestivalController festivalController, ISetController setController)
		{
			this.festivalController = festivalController;
			this.setController = setController;

			this.writer = new ConsoleWriter();
			this.reader = new ConsoleReader();
		}

		public void Run()
		{
			string input = null;
			while((input = this.reader.ReadLine())!="END")
			{
				string[] commandArgs = input.Split();
				string command = commandArgs[0];
				try
				{
					string output = ProcessCommand(command, commandArgs.Skip(1).ToArray());
					this.writer.WriteLine(output);
				}
				catch (InvalidOperationException ex)
				{
					this.writer.WriteLine(string.Format(Consts.Error, ex.Message));
				}
			}
			this.writer.WriteLine(this.festivalController.ProduceReport());
		}

		private string ProcessCommand(string command, string[] commandArgs)
		{
			string output = null;
			switch(command)
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
