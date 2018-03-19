using System;
using System.Collections.Generic;
using System.Text;

public class TyreFactory
{
	public Tyre CreateTyre(List<string> commandArgs)
	{
		string tyreType = commandArgs[4];
		double tyreHardness = double.Parse(commandArgs[5]);
		if (tyreType == "Hard")
		{
			return new HardTyre(tyreType, tyreHardness);
		}
		else if (tyreType == "Ultrasoft")
		{
			double tyreGrip = double.Parse(commandArgs[6]);
			return new UltrasoftTyre(tyreType, tyreHardness, tyreGrip);
		}
		else
		{
			throw new ArgumentException(FailMessages.NotSuchTyre);
		}
	}
}