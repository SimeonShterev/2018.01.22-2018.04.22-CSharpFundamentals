using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		AirBenderNation airBenderNation = new AirBenderNation();
		List<string> issuedWar = new List<string>();
		while (true)
		{
			string[] input = Console.ReadLine().Split();
			string command = input[0];
			switch (command)
			{
				case "Bender":
					string nation = input[1];
					string benderName = input[2];
					int power = int.Parse(input[3]);
					float secondaryParameter = float.Parse(input[4]);
					switch (nation)
					{
						case "Air":
							AirBender airBender = new AirBender(benderName, power, secondaryParameter);
							airBenderNation.AddBenders(airBender);
							break;
						case "Earth":
							EarthBender earthBender = new EarthBender(benderName, power, secondaryParameter);
							break;
						case "Fire":
							FireBender fireBender = new FireBender(benderName, power, secondaryParameter);
							break;
						case "Water":
							WaterBender waterBender = new WaterBender(benderName, power, secondaryParameter);
							break;
					}
					break;
				case "Monument":
					nation = input[1];
					string monumentName = input[2];
					int affinity = int.Parse(input[3]);
					switch (nation)
					{
						case "Air":
							AirMonument airMonument = new AirMonument(monumentName, affinity);
							airBenderNation.AddMonument(airMonument);
							break;
						case "Earth":
							EarthMonument earthMonument = new EarthMonument(monumentName, affinity);
							break;
						case "Fire":
							FireMonument fireMonument = new FireMonument(monumentName, affinity);
							break;
						case "Water":
							WaterMonument waterMonument = new WaterMonument(monumentName, affinity);
							break;
					}
					break;
				case "Status":
					nation = input[1];
					switch (nation)
					{
						case "Air":
							Console.Write($"Air Nation{Environment.NewLine}Benders:");
							if (airBenderNation.ReadBenders.Any())
							{
								Console.WriteLine();
								foreach (var bender in airBenderNation.ReadBenders)
								{
									Console.WriteLine(bender);
								}
							}
							else
							{
								Console.WriteLine(" None");
							}
							Console.Write("Monuments:");
							if (airBenderNation.ReadMonuments.Any())
							{
								Console.WriteLine();
								foreach (var monument in airBenderNation.ReadMonuments)
								{
									Console.WriteLine(monument);
								}
							}
							else
							{
								Console.WriteLine(" None");
							}
							break;
						case "Earth":
							break;
						case "Fire":
							break;
						case "Water":
							break;
					}
					break;
				case "War":
					nation = input[1];
					//implement war here
					string issuedWarElement = $"War {issuedWar.Count + 1} issued by {nation}";
					issuedWar.Add(issuedWarElement);
					break;
				case "Quit":
					foreach (var war in issuedWar)
					{
						Console.WriteLine(war);
					}
					Environment.Exit(0);
					break;
			}
		}
	}
}