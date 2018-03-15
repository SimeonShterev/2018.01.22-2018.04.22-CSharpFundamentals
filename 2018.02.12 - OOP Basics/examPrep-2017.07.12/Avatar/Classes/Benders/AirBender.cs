using System;
using System.Collections.Generic;
using System.Text;

public class AirBender : Bender
{
	public AirBender(string name, int power, double aerialIntegrity)
		: base(name, power, aerialIntegrity) { }

	public override string ToString()
	{
		string result = $"###Air{base.ToString()}Aerial Integrity: {this.SpecialPowerMultiplicator:f2}";
		return result;
	}
}
