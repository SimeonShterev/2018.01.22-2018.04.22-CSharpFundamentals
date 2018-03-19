using System;
using System.Collections.Generic;
using System.Text;

public class BenderFactory
{
	public Bender CreateBender(List<string> benderArgs)
	{
		string nation = benderArgs[0];
		string benderName = benderArgs[1];
		int power = int.Parse(benderArgs[2]);
		double secondaryParameter = double.Parse(benderArgs[3]);
		switch (nation)
		{
			case "Air":
				return new AirBender(benderName, power, secondaryParameter);
			case "Earth":
				return new EarthBender(benderName, power, secondaryParameter);
			case "Fire":
				return new FireBender(benderName, power, secondaryParameter);
			case "Water":
				return new WaterBender(benderName, power, secondaryParameter);
			default:
				throw new ArgumentException("Not such a nation");
		}
	}
}