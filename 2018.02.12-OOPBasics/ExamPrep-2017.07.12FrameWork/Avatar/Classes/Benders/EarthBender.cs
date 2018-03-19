using System;
using System.Collections.Generic;
using System.Text;

public class EarthBender : Bender
{
	public EarthBender(string name, int power, double groundSaturation)
		: base(name, power, groundSaturation) { }

	public override string ToString()
	{
		string result = $"###Earth{base.ToString()}Ground Saturation: {this.SpecialPowerMultiplicator:f2}";
		return result;
	}
}