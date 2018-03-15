using System;
using System.Collections.Generic;
using System.Text;

public class WaterMonument : Monument
{
	public WaterMonument(string name, int waterAffinity)
		: base(name, waterAffinity) { }

	public override string ToString()
	{
		string result = $"###Water{base.ToString()}Water Affinity: {this.Affinity}";
		return result;
	}
}