using System;
using System.Collections.Generic;
using System.Text;

public class SolarProvider : Provider
{
	public SolarProvider(string id, double energyOutput) 
		: base(id, energyOutput) { }

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Solar Provider - {this.Id}")
			.AppendLine($"Energy Output: {this.EnergyOutput}");
		return sb.ToString().TrimEnd();
	}

	public override string RegisterProviderToString()
	{
		string result = $"Successfully registered Solar Provider - {this.Id}";
		return result;
	}
}
