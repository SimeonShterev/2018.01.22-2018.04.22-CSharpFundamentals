using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
	public Harvester CreateHarvester(List<string> arguments)
	{
		string type = arguments[0];
		string id = arguments[1];
		double oreOutPut = double.Parse(arguments[2]);
		double energyRequirement = double.Parse(arguments[3]);
		if (type == "Sonic")
		{
			int sonicFactor = int.Parse(arguments[4]);
			Harvester sonicHarvester = new SonicHarvester(id, oreOutPut, energyRequirement, sonicFactor);
			return sonicHarvester;
		}
		else if (type == "Hammer")
		{
			Harvester hammerHarvester = new HammerHarvester(id, oreOutPut, energyRequirement);
			return hammerHarvester;
		}
		else
			throw new Exception("Not such a type of Harvester");
	}
}