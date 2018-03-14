using System;
using System.Collections.Generic;
using System.Text;

public class PressureProvider : Provider
{
	public PressureProvider(string id, double energyOutput)
		: base(id, energyOutput * 1.5) { }

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"“Pressure Provider - {this.Id}")
			.AppendLine($"Energy Output: {this.EnergyOutput}");
		return sb.ToString().TrimEnd();
	}

	public override string RegisterProviderToString()
	{
		string result = $"Successfully registered Pressure Provider - {this.Id}";
		return result;
	}
}