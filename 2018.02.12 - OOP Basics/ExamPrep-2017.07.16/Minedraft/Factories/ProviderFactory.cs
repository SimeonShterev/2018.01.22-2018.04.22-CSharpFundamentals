using System;
using System.Collections.Generic;
using System.Text;

public class ProviderFactory
{
	public Provider CreateProvider(List<string> arguments)
	{
		string type = arguments[0];
		string id = arguments[1];
		double energyOutput = double.Parse(arguments[2]);
		if (type == "Solar")
		{
			Provider solarProvider = new SolarProvider(id, energyOutput);
			return solarProvider;
		}
		else if (type == "Pressure")
		{
			Provider pressureProvider = new PressureProvider(id, energyOutput);
			return pressureProvider;
		}
		else
			throw new Exception("Not such a provider type");
	}
}