using System;
using System.Collections.Generic;
using System.Text;

public class WaterMonument : Monument
{
	public WaterMonument(string name, int waterAffinity)
		: base(name)
	{
		this.WaterAffinity = waterAffinity;
	}

	public int WaterAffinity { get; set; }
}