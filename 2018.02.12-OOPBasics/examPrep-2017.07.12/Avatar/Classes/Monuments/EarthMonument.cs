using System;
using System.Collections.Generic;
using System.Text;

public class EarthMonument : Monument
{
	public EarthMonument(string name, int earthAffinity)
		: base(name, earthAffinity) { }

	public override string ToString()
	{
		string result = $"###Earth{base.ToString()}Earth Affinity: {this.Affinity}";
		return result;
	}
}