using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
			DungeonMaster dungeonMaster = new DungeonMaster();
			string input;
			while(true)
			{
				string[] commandArgs = Console.ReadLine().Split();
				string command = commandArgs[0];
				commandArgs = commandArgs.Skip(1).ToArray();
				string output;
				bool isGameOver = false;
				//Put whole swtich case in Try-Catch-Block
				switch(command)
				{
					case "JoinParty":
						try
						{
							output = dungeonMaster.JoinParty(commandArgs);
							Console.WriteLine(output);
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
						break;
					case "AddItemToPool":
						try
						{
							output = dungeonMaster.AddItemToPool(commandArgs);
							Console.WriteLine(output);
						}
						catch (ArgumentException ex)
						{
							Console.WriteLine(ex.Message);
						}
						break;
					case "PickUpItem":
						try
						{
							output = dungeonMaster.PickUpItem(commandArgs);
							Console.WriteLine(output);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
						break;
					case "UseItem":
						output = dungeonMaster.UseItem(commandArgs);
						Console.WriteLine(output);
						break;
					case "UseItemOn":
						output = dungeonMaster.UseItemOn(commandArgs);
						Console.WriteLine(output);
						break;
					case "GiveCharacterItem":
						output = dungeonMaster.GiveCharacterItem(commandArgs);
						Console.WriteLine(output);
						break;
					case "GetStats":
						output = dungeonMaster.GetStats();
						Console.WriteLine(output);
						break;
					case "Attack":
						output = dungeonMaster.Attack(commandArgs);
						Console.WriteLine(output);
						break;
					case "Heal":
						output = dungeonMaster.Heal(commandArgs);
						Console.WriteLine(output);
						break;
					case "EndTurn":
						output = dungeonMaster.EndTurn(commandArgs);
						Console.WriteLine(output);
						break;
					case "IsGameOver":
						isGameOver = dungeonMaster.IsGameOver();
						break;
				}
				if (isGameOver)
				{
					break;
				}
			}
		}
	}
}