using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
	public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
		: base(id, oreOutput, energyRequirement)
	{
		this.EnergyRequirement = energyRequirement / sonicFactor;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Sonic Harvester - {this.Id}")
			.AppendLine($"Ore Output: {this.OreOutput}")
			.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
		return sb.ToString().TrimEnd();
	}

	public override string RegisterHarvesterToString()
	{
		string result = $"Successfully registered Sonic Harvester - {this.Id}";
		return result;
	}
}