using System;
using System.Collections.Generic;
using System.Text;

public class WaterBender : Bender
{
	public WaterBender(string name, int power, double waterClarity)
		: base(name, power, waterClarity) { }

	public override string ToString()
	{
		string result = $"###Water{base.ToString()}Water Clarity: {this.SpecialPowerMultiplicator:f2}";
		return result;
	}
}