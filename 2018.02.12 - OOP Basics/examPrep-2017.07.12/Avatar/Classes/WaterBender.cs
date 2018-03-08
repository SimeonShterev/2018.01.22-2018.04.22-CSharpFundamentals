using System;
using System.Collections.Generic;
using System.Text;

public class WaterBender : Bender
{
	public WaterBender(string name, int power, float waterClarity)
		: base(name, power)
	{
		this.waterClarity = waterClarity;
	}

	public float waterClarity { get; set; }
}