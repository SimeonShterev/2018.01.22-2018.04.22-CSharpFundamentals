using System;
using System.Collections.Generic;
using System.Text;

public class MonumentFactory
{
	public Monument CreateMonument(List<string> monumentArgs)
	{
		string nation = monumentArgs[0];
		string monumentName = monumentArgs[1];
		int affinity = int.Parse(monumentArgs[2]);
		switch (nation)
		{
			case "Air":
				return new AirMonument(monumentName, affinity);
			case "Earth":
				return new EarthMonument(monumentName, affinity);
			case "Fire":
				return new FireMonument(monumentName, affinity);
			case "Water":
				return new WaterMonument(monumentName, affinity);
			default:
				throw new ArgumentException("Not such a Monument type");
		}
	}
}