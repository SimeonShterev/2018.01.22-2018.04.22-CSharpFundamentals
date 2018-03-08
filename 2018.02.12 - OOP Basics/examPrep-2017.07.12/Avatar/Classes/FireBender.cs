using System;
using System.Collections.Generic;
using System.Text;

public class FireBender : Bender
{
	public FireBender(string name, int power, float heatAgression)
		: base(name, power)
	{
		this.HeatAggresion = heatAgression;
	}

	public float HeatAggresion { get; set; }
}