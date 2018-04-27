using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Core.IO;
using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
		private DungeonMaster master;
		private IWriter writer;
		private IReader reader;

		public Engine()
		{
			this.master = new DungeonMaster();
			this.writer = new ConsoleWriter();
			this.reader = new ConsoleReader();
		}

		public void Run()
		{
			string input = null;
			while (!string.IsNullOrEmpty(input = this.reader.ReadLine()))
			{
				
				string[] commandArgs = input.Split();
				string command = commandArgs[0];
				string[] args = commandArgs.Skip(1).ToArray();

				try
				{
					string output = ProcessCommand(args, command);
					this.writer.WriteLine(output);
				}
				catch(InvalidOperationException ex)
				{
					this.writer.WriteLine($"Invalid Operation: {ex.Message}");
				}
				catch(ArgumentException ex)
				{
					this.writer.WriteLine($"Parameter Error: {ex.Message}");
				}

				if(this.master.IsGameOver())
				{
					break;
				}
			}

			this.writer.WriteLine(Consts.FinalStats);
			this.writer.WriteLine(this.master.GetStats());
		}

		private string ProcessCommand(string[] args, string command)
		{
			string output = null;
			switch(command)
			{
				case "JoinParty":
					output = this.master.JoinParty(args);
					break;
				case "AddItemToPool":
					output = this.master.AddItemToPool(args);
					break;
				case "PickUpItem":
					output = this.master.PickUpItem(args);
					break;
				case "UseItem":
					output = this.master.UseItem(args);
					break;
				case "UseItemOn":
					output = this.master.UseItemOn(args);
					break;
				case "GiveCharacterItem":
					output = this.master.GiveCharacterItem(args);
					break;
				case "Attack":
					output = this.master.Attack(args);
					break;
				case "Heal":
					output = this.master.Heal(args);
					break;
				case "GetStats":
					output = this.master.GetStats();
					break;
				case "EndTurn":
					output = this.master.EndTurn(args);
					break;
			}
			return output;
		}
	}
}
