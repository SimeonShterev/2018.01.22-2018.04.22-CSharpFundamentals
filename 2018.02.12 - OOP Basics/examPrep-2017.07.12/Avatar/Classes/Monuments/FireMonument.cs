using System;
using System.Collections.Generic;
using System.Text;

public class FireMonument : Monument
{
	public FireMonument(string name, int fireAffinity)
		: base(name, fireAffinity) { }

	public override string ToString()
	{
		string result = $"###Fire{base.ToString()}Fire Affinity: {this.Affinity}";
		return result;
	}
}