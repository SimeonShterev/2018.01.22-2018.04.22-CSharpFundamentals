using System;
using System.Collections.Generic;
using System.Text;

public class FireBender : Bender
{
	public FireBender(string name, int power, double heatAgression)
		: base(name, power, heatAgression) { }

	public override string ToString()
	{
		string result = $"###Fire{base.ToString()}Heat Agression: {this.SpecialPowerMultiplicator:f2}";
		return result;
	}
}