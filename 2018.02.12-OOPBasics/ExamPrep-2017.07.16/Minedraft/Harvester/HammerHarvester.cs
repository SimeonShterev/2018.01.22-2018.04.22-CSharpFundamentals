using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
	public HammerHarvester(string id, double oreOutput, double energyRequirement)
		: base(id, oreOutput * 3, energyRequirement * 2) { }

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Hammer Harvester - {this.Id}")
			.AppendLine($"Ore Output: {this.OreOutput}")
			.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
		return sb.ToString().TrimEnd();
	}

	public override string RegisterHarvesterToString()
	{
		string result = $"Successfully registered Hammer Harvester - {this.Id}";
		return result;
	}
}