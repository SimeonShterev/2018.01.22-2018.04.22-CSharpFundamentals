using System;
using System.Collections.Generic;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
		string typeName = args[1] + args[0];
		Type harvesterType = Type.GetType(typeName);

        int id = int.Parse(args[2]);
		double oreOutput = double.Parse(args[3]);
		double energyReq = double.Parse(args[4]);

		IHarvester harvester = (IHarvester)Activator.CreateInstance(harvesterType, id, oreOutput, energyReq);
        return harvester;
    }
}