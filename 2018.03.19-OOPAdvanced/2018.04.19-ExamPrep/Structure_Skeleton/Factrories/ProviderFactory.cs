using System;
using System.Collections.Generic;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
		string typeName = args[0] + "Provider";
		Type providerType = Type.GetType(typeName);

        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);

		IProvider provider = (IProvider)Activator.CreateInstance(providerType, id, energyOutput);
        return provider;
    }
}