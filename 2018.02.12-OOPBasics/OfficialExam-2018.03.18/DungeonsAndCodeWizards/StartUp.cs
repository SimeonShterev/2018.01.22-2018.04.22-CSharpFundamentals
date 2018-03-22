using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
			DungeonMaster dungeonMaster = new DungeonMaster();
			string inpit;
			while (true)
			{
				inpit = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(inpit))
				{
					break;
				}
				string[] commandArgs = inpit.Split();
				string command = commandArgs[0];
				commandArgs = commandArgs.Skip(1).ToArray();
				string output;
				try
				{
					output = ReadCommand(commandArgs, dungeonMaster, command);
					Console.WriteLine(output);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine("Parameter Error: " + ex.Message);
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine("Invalid Operation: " + ex.Message);
				}
				if (dungeonMaster.IsGameOver())
				{
					string finalStats = dungeonMaster.GetStats();
					Console.WriteLine("Final stats:" + Environment.NewLine + finalStats);
					break;
				}
			}
		}

		private static string ReadCommand(string[] commandArgs, DungeonMaster dungeonMaster, string command)
		{
			string output = string.Empty;
			switch (command)
			{
				case "JoinParty":
					output = dungeonMaster.JoinParty(commandArgs);
					break;
				case "AddItemToPool":
					output = dungeonMaster.AddItemToPool(commandArgs);
					break;
				case "PickUpItem":
					output = dungeonMaster.PickUpItem(commandArgs);
					break;
				case "UseItem":
					output = dungeonMaster.UseItem(commandArgs);
					break;
				case "UseItemOn":
					output = dungeonMaster.UseItemOn(commandArgs);
					break;
				case "GiveCharacterItem":
					output = dungeonMaster.GiveCharacterItem(commandArgs);
					break;
				case "GetStats":
					output = dungeonMaster.GetStats();
					break;
				case "Attack":
					output = dungeonMaster.Attack(commandArgs);
					break;
				case "Heal":
					output = dungeonMaster.Heal(commandArgs);
					break;
				case "EndTurn":
					output = dungeonMaster.EndTurn();
					break;
			}
			return output;
		}
	}
}