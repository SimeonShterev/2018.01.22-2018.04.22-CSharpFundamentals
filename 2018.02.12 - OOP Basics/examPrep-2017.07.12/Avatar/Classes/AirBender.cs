using System;
using System.Collections.Generic;
using System.Text;

public class AirBender : Bender
{
	public AirBender(string name, int power, float aerialIntegrity)
		: base(name, power)
	{
		this.AerialIntegrity = aerialIntegrity;
	}

	public float AerialIntegrity { get; set; }

	public override string ToString()
	{
		string result = $"###Air{base.ToString()}Aerial Integrity: {this.AerialIntegrity:f2}";
		return result;
	}
}
