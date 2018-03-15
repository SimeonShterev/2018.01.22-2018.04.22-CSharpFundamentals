using System;
using System.Collections.Generic;
using System.Text;

public class AirMonument : Monument
{
	public AirMonument(string name, int airAffinity)
		: base(name, airAffinity) { }

	public override string ToString()
	{
		string result = $"###Air{base.ToString()}Air Affinity: {this.Affinity}";
		return result;
	}
}