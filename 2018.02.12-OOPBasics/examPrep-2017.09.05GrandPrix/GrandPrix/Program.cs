using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		int lapsNum = int.Parse(Console.ReadLine());
		int trackLenght = int.Parse(Console.ReadLine());
		RaceTower raceTower = new RaceTower();
		raceTower.SetTrackInfo(lapsNum, trackLenght);
		while (true)
		{
			List<string> commandArgs = Console.ReadLine().Split().ToList();
			string command = commandArgs[0];
			commandArgs.RemoveAt(0);
			string output;
			switch (command)
			{
				case "RegisterDriver":
					raceTower.RegisterDriver(commandArgs);
					break;
				case "Leaderboard":
					output = raceTower.GetLeaderboard();
					Console.WriteLine(output);
					break;
				case "CompleteLaps":
					output = raceTower.CompleteLaps(commandArgs);
					if (output.Length != 0)
						Console.WriteLine(output);
					break;
				case "Box":
					raceTower.DriverBoxes(commandArgs);
					break;
				case "ChangeWeather":
					raceTower.ChangeWeather(commandArgs);
					break;
			}
			if(raceTower.isRaceOver)
			{
				break;
			}
		}
		Console.WriteLine(raceTower.winner.AnnounceWinner());
	}
}