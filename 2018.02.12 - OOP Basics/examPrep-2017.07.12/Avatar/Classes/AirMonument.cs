using System;
using System.Collections.Generic;
using System.Text;

public class AirMonument : Monument
{
	public AirMonument(string name, int airAffinity) 
		: base(name)
	{
		this.AirAffinity = airAffinity;
	}

	public int AirAffinity { get; set; }

	public override string ToString()
	{
		string result = $"###Air{base.ToString()}Air Affinity: {this.AirAffinity}";
		return result;
	}
}