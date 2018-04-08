using System;
using System.Collections.Generic;
using System.Text;

public class GemFactory
{
	public Gem CreateGem(string[] gemData)
	{
		string gemClarity = gemData[0];
		GemClarity clarity = Enum.Parse<GemClarity>(gemClarity);
		string gemType = gemData[1];
		Type type = Type.GetType(gemType);
		Gem gem = (Gem)Activator.CreateInstance(type, new object[] { clarity });
		return gem;
	}
}