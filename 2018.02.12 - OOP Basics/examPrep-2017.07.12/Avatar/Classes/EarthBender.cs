using System;
using System.Collections.Generic;
using System.Text;

public class EarthBender : Bender
{
	public EarthBender(string name, int power, float groundSaturation)
		: base(name, power)
	{
		this.GroundSaturation = groundSaturation;
	}

	public float GroundSaturation { get; set; }
}